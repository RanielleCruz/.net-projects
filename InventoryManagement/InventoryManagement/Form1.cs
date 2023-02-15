using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace InventoryManagement
{
    public partial class Form1 : Form
    {
        public string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        public int _Quantity;
        public double _SellPrice;
        private InventoryQuery inventoryQuery;

        BindingSource showProductList;

        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            try
            {
                inventoryQuery = new InventoryQuery();

                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Convert.ToInt32(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                    _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;

                inventoryQuery.AddItem(_ProductName, _Category, _MfgDate, _ExpDate, _Description, _Quantity, _SellPrice);
                refreshInventoryList();

            }

            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = {"Beverages", "Bread/Bakery", "Canned/Jarred Goods",
                "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other"};
            refreshInventoryList();

            inventoryQuery = new InventoryQuery();

            refreshInventoryList();

            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }

        public Form1()
        {
            showProductList = new BindingSource();

            InitializeComponent();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (gridViewProductList.SelectedRows.Count > 0)
            {
                int selectedRowIndex = gridViewProductList.CurrentCell.RowIndex;
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Convert.ToInt32(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.RemoveAt(selectedRowIndex);
                inventoryQuery.RemoveItem(_ProductName, _Category, _MfgDate, _ExpDate, _Description, _Quantity, _SellPrice);
                refreshInventoryList();
            }
        }

        public void refreshInventoryList()
        {

            inventoryQuery = new InventoryQuery();

            inventoryQuery.Display();
            gridViewProductList.DataSource = inventoryQuery.bindingSource;
        }
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+S"))
            {
                try
                {

                }

                catch (NumberFormatException ne)
                {
                    MessageBox.Show(ne.Message);
                }

                catch (CurrencyFormatException ce)
                {
                    MessageBox.Show(ce.Message);
                }

                catch (StringFormatException se)
                {
                    MessageBox.Show(se.Message);
                }

                finally
                {

                }
            }
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
            {
                try
                {

                }

                catch (NumberFormatException ne)
                {
                    MessageBox.Show(ne.Message);
                }

                catch (CurrencyFormatException ce)
                {
                    MessageBox.Show(ce.Message);
                }

                catch (StringFormatException se)
                {
                    MessageBox.Show(se.Message);
                }
                finally
                {

                }

            }
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                try
                {

                }

                catch (NumberFormatException ne)
                {
                    MessageBox.Show(ne.Message);
                }

                catch (CurrencyFormatException ce)
                {
                    MessageBox.Show(ce.Message);
                }

                catch (StringFormatException se)
                {
                    MessageBox.Show(se.Message);
                }

                finally
                {

                }
            return Convert.ToDouble(price);
        }
    }
    class NumberFormatException : Exception
    {
        public NumberFormatException(string numFormatEx) : base(numFormatEx) { }
    }

    class StringFormatException : Exception
    {
        public StringFormatException(string strFormatEx) : base(strFormatEx) { }

    }

    class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string curFormatEx) : base(curFormatEx) { }
    }
    class ProductClass
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

        public ProductClass(string ProductName, string Category, string MfgDate,
            string ExpDate, double Price, int Quantity, string Description)
        {
            this._Quantity = Quantity;
            this._SellingPrice = Price;
            this._ProductName = ProductName;
            this._Category = Category;
            this._ManufacturingDate = MfgDate;
            this._ExpirationDate = ExpDate;
            this._Description = Description;
        }

        public string productName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }

        public string category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this._Category = value;
            }

        }

        public string manufacturingDate
        {
            get
            {
                return this._ManufacturingDate;
            }
            set
            {
                this._ManufacturingDate = value;
            }

        }

        public string expirationDate
        {
            get
            {
                return this._ExpirationDate;
            }
            set
            {
                this._ExpirationDate = value;
            }

        }

        public string description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }

        }

        public int quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }

        }

        public double sellingPrice
        {
            get
            {
                return this._SellingPrice;
            }
            set
            {
                this._SellingPrice = value;
            }

        }
    }
}
