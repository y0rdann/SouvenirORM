using SouvenirsORM.Controllers;
using SouvenirsORM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SouvenirsORM
{
    public partial class Display : Form
    {
        SouvenirLogic souvenirController = new SouvenirLogic();
        SouvenirTypeLogic souvenirTypeController = new SouvenirTypeLogic();

        public Display()
        {
            InitializeComponent();
        }
        private void LoadRecord(Souvenir souvenir)
        {
            txtId.BackColor = Color.White;
            txtName.Text = souvenir.Id.ToString();
            txtPrice.Text = souvenir.Price.ToString();
            cmbType.Text = souvenir.SouvenirTypes.Name;
        }
        private void ClearScreen()
        {
            txtId.BackColor = Color.White;
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            cmbType.Text = "";

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Display_Load(object sender, EventArgs e)
        {
            List<SouvenirType> allSouvenirTypes = souvenirTypeController.GetAllSouvenirTypes();
            cmbType.DataSource = allSouvenirTypes;  
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Id";
            btnSelect_Click(sender, e); 
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<Souvenir> allSouvenirs = souvenirController.GetAll();
            list1.Items.Clear();
            foreach (var item in allSouvenirs)
            {
                list1.Items.Add($"{item.Id}. {item.Name}. - Price: {item.Price}  Breed: {item.SouvenirTypes.Name}");

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }
            Souvenir newSouvenir = new Souvenir();
            newSouvenir.Price = int.Parse(txtPrice.Text);
            newSouvenir.Name = txtName.Text;
            newSouvenir.SouvenirTypesId = (int)cmbType.SelectedValue;
            souvenirController.Create(newSouvenir);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSelect_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId= int.Parse(txtId.Text);
            }
            Souvenir foundSouvenir = souvenirController.Get(findId);
            if (foundSouvenir==null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                txtId.BackColor= Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(foundSouvenir);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Souvenir foundSouvenir = souvenirController.Get(findId);
                if (foundSouvenir==null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    txtId.BackColor= Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(foundSouvenir);
            }
            else
            {
                Souvenir updatedSouvenir=new Souvenir();
                updatedSouvenir.Name = txtName.Text;
                updatedSouvenir.Price = double.Parse(txtPrice.Text);
                updatedSouvenir.SouvenirTypesId = (int)cmbType.SelectedValue;
                souvenirController.Update(findId, updatedSouvenir);
            }
            btnSelect_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Souvenir foundSouvenir = souvenirController.Get(findId);
                if (foundSouvenir == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(foundSouvenir);
                DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +findId + " ?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer==DialogResult.Yes)
                {
                    souvenirController.Delete(findId);
                }
                btnSelect_Click(sender, e);
            }
        }
    }
}
