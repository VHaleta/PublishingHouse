using PublishingHouse.Constants;
using PublishingHouse.Helpers;
using PublishingHouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PublishingHouse
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridViewMain.MultiSelect = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Session.Table = Table.Person;
            if(Session.IDph != 0)
            {
                login_mmi.Visible = false;
                printingHouse_mmi.Visible = false;
                publicationType_mmi.Visible = false;
            }
            HideBoxes();
            groupBoxPerson.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);

        }

        private void HideBoxes()
        {
            groupBoxAuthor.Visible = false;
            groupBoxAuthorship.Visible = false;
            groupBoxEntity.Visible = false;
            groupBoxLogin.Visible = false;
            groupBoxOrder.Visible = false;
            groupBoxPerson.Visible = false;
            groupBoxPrintingHouse.Visible = false;
            groupBoxPublication.Visible = false;
            groupBoxPublicationType.Visible = false;
            groupBoxRepresentative.Visible = false;
        }

        private void LoadDataGridView(DataGridView dataGridView, Table table, Label header)
        {
            switch (table)
            {
                case Table.Person:
                    header.Text = "Person";
                    dataGridView.Columns.Add(Person.Id_, Person.Id_);
                    dataGridView.Columns.Add(Person.Name_, Person.Name_);
                    dataGridView.Columns.Add(Person.Address_, Person.Address_);
                    dataGridView.Columns.Add(Person.Phone_, Person.Phone_);
                    foreach (var item in Database.persons)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.StringToDataBox(item.Name), Converter.StringToDataBox(item.Address), Converter.StringToDataBox(item.Phone));
                    break;

                case Table.PublishingOrder:
                    header.Text = "Publishing Order";
                    dataGridView.Columns.Add(PublishingOrder.Id_, PublishingOrder.Id_);
                    dataGridView.Columns.Add(PublishingOrder.IdPrintingHouse_, PublishingOrder.IdPrintingHouse_);
                    dataGridView.Columns.Add(PublishingOrder.OrderStatus_, PublishingOrder.OrderStatus_);
                    dataGridView.Columns.Add(PublishingOrder.IdPublication_, PublishingOrder.IdPublication_);
                    dataGridView.Columns.Add(PublishingOrder.DateOrder_, PublishingOrder.DateOrder_);
                    dataGridView.Columns.Add(PublishingOrder.DateCompliting_, PublishingOrder.DateCompliting_);
                    dataGridView.Columns.Add(PublishingOrder.IdRepresentative_, PublishingOrder.IdRepresentative_);
                    foreach (var item in Database.publishingOrders)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.IntToString(item.IdPrintingHouse), item.Status, Converter.IntToString(item.IdPublication), item.DateOrder.ToString("dd.MM.yyyy"), item.DateCompliting.ToString("dd.MM.yyyy"), Converter.IntToString(item.IdRepresentative));
                    break;

                case Table.Publication:
                    header.Text = "Publication";
                    dataGridView.Columns.Add(Publication.Id_, Publication.Id_);
                    dataGridView.Columns.Add(Publication.Name_, Publication.Name_);
                    dataGridView.Columns.Add(Publication.Type_, Publication.Type_);
                    dataGridView.Columns.Add(Publication.Size_, Publication.Size_);
                    dataGridView.Columns.Add(Publication.PrintingCount_, Publication.PrintingCount_);
                    foreach (var item in Database.publications)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.StringToDataBox(item.Name), Converter.StringToDataBox(item.Type), Converter.IntToString(item.Size), Converter.IntToString(item.PrintingCount));
                    break;

                case Table.Entity:
                    header.Text = "Entity";
                    dataGridView.Columns.Add(Entity.Id_, Entity.Id_);
                    dataGridView.Columns.Add(Entity.Name_, Entity.Name_);
                    foreach (var item in Database.entities)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.StringToDataBox(item.Name));
                    break;

                case Table.PublicationType:
                    header.Text = "Publication Type";
                    dataGridView.Columns.Add(PublicationType.Type_, PublicationType.Type_);
                    foreach (var item in Database.publicationTypes)
                        dataGridView.Rows.Add(Converter.StringToDataBox(item.Type));
                    break;

                case Table.Login:
                    header.Text = "Login";
                    dataGridView.Columns.Add(Login.Id_, Login.Id_);
                    dataGridView.Columns.Add(Login.Username_, Login.Username_);
                    dataGridView.Columns.Add(Login.Password_, Login.Password_);
                    foreach (var item in Database.logins)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.StringToDataBox(item.Username), Converter.StringToDataBox(item.Password));
                    break;

                case Table.Author:
                    header.Text = "Author";
                    dataGridView.Columns.Add(Author.Id_, Author.Id_);
                    dataGridView.Columns.Add(Author.AdditionalInfo_, Author.AdditionalInfo_);
                    foreach (var item in Database.authors)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.StringToDataBox(item.AdditionalInfo));
                    break;

                case Table.Authorship:
                    header.Text = "Authorship";
                    dataGridView.Columns.Add(Authorship.IdAuthor_, Authorship.IdAuthor_);
                    dataGridView.Columns.Add(Authorship.IdPublication_, Authorship.IdPublication_);
                    foreach (var item in Database.authorships)
                        dataGridView.Rows.Add(Converter.IntToString(item.IdAuthor), Converter.IntToString(item.IdPublication));
                    break;
                case Table.PrintingHouse:
                    header.Text = "Printing House";
                    dataGridView.Columns.Add(PrintingHouse.Id_, PrintingHouse.Id_);
                    dataGridView.Columns.Add(PrintingHouse.Name_, PrintingHouse.Name_);
                    dataGridView.Columns.Add(PrintingHouse.Address_, PrintingHouse.Address_);
                    foreach (var item in Database.printingHouses)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.StringToDataBox(item.Name), Converter.StringToDataBox(item.Address));
                    break;

                case Table.Representative:
                    header.Text = "Representative";
                    dataGridView.Columns.Add(Representative.Id_, Representative.Id_);
                    dataGridView.Columns.Add(Representative.IdEntity_, Representative.IdEntity_);
                    dataGridView.Columns.Add(Representative.IdAuthor_, Representative.IdAuthor_);
                    foreach (var item in Database.representatives)
                        dataGridView.Rows.Add(Converter.IntToString(item.Id), Converter.IntToString(item.IdEntity), Converter.IntToString(item.IdAuthor));
                    break;

                default: break;
            }

            //TODO: add additional data
        }

        private void LoadBox()
        {
            switch (Session.Table)
            {
                case Table.Person:
                    textBox_Person_ID.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Person.Id_].Value?.ToString());
                    textBox_Person_Name.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Person.Name_].Value?.ToString());
                    richTextBox_Person_Address.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Person.Address_].Value?.ToString());
                    textBox_Person_Phone.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Person.Phone_].Value?.ToString());
                    break;
                case Table.PublishingOrder:
                    comboBox_Order_IDPH.SelectedItem = null;
                    comboBox_Order_Status.SelectedItem = null;
                    comboBox_Order_IDPublication.SelectedItem = null;
                    comboBox_Order_IDRepres.SelectedItem = null;
                    textBox_Order_ID.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.Id_].Value?.ToString());
                    comboBox_Order_IDPH.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.IdPrintingHouse_].Value?.ToString();
                    comboBox_Order_Status.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.OrderStatus_].Value?.ToString();
                    comboBox_Order_IDPublication.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.IdPublication_].Value?.ToString();
                    dateTimePicker_Order_DateOrder.Value = Converter.DataToDateTime(dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.DateOrder_].Value?.ToString());
                    dateTimePicker_Order_DateComp.Value = Converter.DataToDateTime(dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.DateCompliting_].Value?.ToString());
                    comboBox_Order_IDRepres.SelectedItem =  dataGridViewMain.SelectedRows[0].Cells[PublishingOrder.IdRepresentative_].Value?.ToString();
                    break;
                case Table.Publication:
                    comboBox_Publication_Type.SelectedItem = null;
                    textBox_Publication_ID.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Publication.Id_].Value?.ToString());
                    textBox_Publication_Name.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Publication.Name_].Value?.ToString());
                    comboBox_Publication_Type.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[Publication.Type_].Value?.ToString();
                    textBox_Publication_Size.Text = (dataGridViewMain.SelectedRows[0].Cells[Publication.Size_].Value != null) ? dataGridViewMain.SelectedRows[0].Cells[Publication.Size_].Value.ToString() : null;
                    textBox_Publication_PrintingCount.Text = (dataGridViewMain.SelectedRows[0].Cells[Publication.PrintingCount_].Value != null) ? dataGridViewMain.SelectedRows[0].Cells[Publication.PrintingCount_].Value.ToString() : null;
                    break;
                case Table.Author:
                    comboBox_Author_ID.SelectedItem = null;
                    comboBox_Author_ID.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[Author.Id_].Value?.ToString();
                    richTextBox_Author_Info.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Author.AdditionalInfo_].Value.ToString());
                    break;
                case Table.Authorship:
                    comboBox_Authorship_IDAuthor.SelectedItem = null;
                    comboBox_Authorship_IDPublication.SelectedItem = null;
                    comboBox_Authorship_IDAuthor.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[Authorship.IdAuthor_].Value?.ToString();
                    comboBox_Authorship_IDPublication.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[Authorship.IdPublication_].Value?.ToString();
                    break;
                case Table.Entity:
                    textBox_Entity_ID.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Entity.Id_].Value.ToString());
                    textBox_Entity_Name.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Entity.Name_].Value.ToString());
                    break;
                case Table.PublicationType:
                    textBoxPublicationType.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[PublicationType.Type_].Value.ToString());
                    break;
                case Table.PrintingHouse:
                    textBox_PH_ID.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[PrintingHouse.Id_].Value.ToString());
                    textBox_PH_Name.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[PrintingHouse.Name_].Value.ToString());
                    richTextBox_PH_Address.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[PrintingHouse.Address_].Value.ToString());
                    break;
                case Table.Login:
                    comboBox_Login_IDPH.SelectedItem = null;
                    comboBox_Login_IDPH.SelectedItem = dataGridViewMain.SelectedRows[0].Cells[Login.Id_].Value?.ToString();
                    textBox_Login_Username.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Login.Username_].Value.ToString());
                    textBox_Login_Password.Text = Converter.DataToString(dataGridViewMain.SelectedRows[0].Cells[Login.Password_].Value.ToString());
                    break;
                    //TODO: add representative

            }
            buttonSaveChanges.Enabled = false;
        }

        private void ClearData()
        {
            dataGridViewMain.Rows.Clear();
            dataGridViewMain.Columns.Clear();
            dataGridViewAdd1.Rows.Clear();
            dataGridViewAdd1.Columns.Clear();
            dataGridViewAdd2.Rows.Clear();
            dataGridViewAdd2.Columns.Clear();
            dataGridViewAdd3.Rows.Clear();
            dataGridViewAdd3.Columns.Clear();
        }

        private void dataGridViewMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedCells.Count < 1) return;
            dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Selected = true;
            LoadBox();
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            switch (Session.Table)
            {
                case Table.Person:
                    Person person = new Person();
                    person.Id = Converter.StringToInt(textBox_Person_ID.Text);
                    person.Name = textBox_Person_Name.Text;
                    person.Address = richTextBox_Person_Address.Text;
                    person.Phone = textBox_Person_Phone.Text;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Person.Id_].Value = Converter.StringToDataBox(textBox_Person_ID.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Person.Name_].Value = Converter.StringToDataBox(textBox_Person_Name.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Person.Address_].Value = Converter.StringToDataBox(richTextBox_Person_Address.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Person.Phone_].Value = Converter.StringToDataBox(textBox_Person_Phone.Text);
                    Database.SaveChanges(Database.persons[dataGridViewMain.SelectedCells[0].RowIndex], person);
                    break;
                case Table.PublishingOrder:
                    PublishingOrder order = new PublishingOrder();
                    order.Id = Converter.StringToInt(textBox_Order_ID.Text);
                    order.IdPublication = Converter.StringToInt(comboBox_Order_IDPH.SelectedItem?.ToString());
                    order.Status = OrderStatusHelper.StringToEnum(comboBox_Order_Status.SelectedItem?.ToString());
                    order.IdPublication = Converter.StringToInt(comboBox_Order_IDPublication.SelectedItem?.ToString());
                    order.DateOrder = dateTimePicker_Order_DateOrder.Value;
                    order.DateCompliting = dateTimePicker_Order_DateComp.Value;
                    order.IdRepresentative = Converter.StringToInt(comboBox_Order_IDRepres.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.Id_].Value = Converter.StringToDataBox(textBox_Order_ID.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.IdPrintingHouse_].Value = Converter.StringToDataBox(comboBox_Order_IDPH.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.OrderStatus_].Value = Converter.StringToDataBox(comboBox_Order_Status.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.IdPublication_].Value = Converter.StringToDataBox(comboBox_Order_IDPublication.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.DateOrder_].Value = dateTimePicker_Order_DateOrder.Value.ToString("dd.MM.yyyy");
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.DateCompliting_].Value = dateTimePicker_Order_DateComp.Value.ToString("dd.MM.yyyy");
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublishingOrder.IdRepresentative_].Value = Converter.StringToDataBox(comboBox_Order_IDRepres.SelectedItem?.ToString());
                    Database.SaveChanges(Database.publishingOrders[dataGridViewMain.SelectedCells[0].RowIndex], order);
                    break;
                case Table.Publication:
                    Publication publication = new Publication();
                    publication.Id = Converter.StringToInt(textBox_Publication_ID.Text);
                    publication.Name = textBox_Publication_Name.Text;
                    publication.Type = comboBox_Publication_Type.SelectedItem?.ToString();
                    publication.Size = Converter.StringToInt(textBox_Publication_Size.Text);
                    publication.PrintingCount = Converter.StringToInt(textBox_Publication_PrintingCount.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Publication.Id_].Value = Converter.StringToDataBox(textBox_Publication_ID.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Publication.Name_].Value = Converter.StringToDataBox(textBox_Publication_Name.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Publication.Type_].Value = Converter.StringToDataBox(comboBox_Publication_Type.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Publication.Size_].Value = Converter.StringToDataBox(textBox_Publication_Size.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Publication.PrintingCount_].Value = Converter.StringToDataBox(textBox_Publication_PrintingCount.Text);
                    Database.SaveChanges(Database.publications[dataGridViewMain.SelectedCells[0].RowIndex], publication);
                    break;
                case Table.Author:
                    Author author = new Author();
                    author.Id = Converter.StringToInt(comboBox_Author_ID.SelectedItem?.ToString());
                    author.AdditionalInfo = richTextBox_Author_Info.Text;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Author.Id_].Value = Converter.StringToDataBox(comboBox_Author_ID.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Author.AdditionalInfo_].Value = Converter.StringToDataBox(richTextBox_Author_Info.Text);
                    Database.SaveChanges(Database.authors[dataGridViewMain.SelectedCells[0].RowIndex], author);
                    break;
                case Table.Authorship:
                    Authorship authorship = new Authorship();
                    authorship.IdAuthor = Converter.StringToInt(comboBox_Authorship_IDAuthor.SelectedItem?.ToString());
                    authorship.IdPublication = Converter.StringToInt(comboBox_Authorship_IDPublication.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Authorship.IdAuthor_].Value = Converter.StringToDataBox(comboBox_Authorship_IDAuthor.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Authorship.IdPublication_].Value = Converter.StringToDataBox(comboBox_Authorship_IDPublication.SelectedItem?.ToString());
                    break;
                case Table.Entity:
                    Entity entity = new Entity();
                    entity.Id = int.Parse(textBox_Entity_ID.Text);
                    entity.Name = textBox_Entity_Name.Text;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Entity.Id_].Value = Converter.StringToDataBox(textBox_Entity_ID.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Entity.Name_].Value = Converter.StringToDataBox(textBox_Entity_Name.Text);
                    Database.SaveChanges(Database.entities[dataGridViewMain.SelectedCells[0].RowIndex], entity);
                    break;
                case Table.PublicationType:
                    PublicationType publicationType = new PublicationType();
                    publicationType.Type = textBoxPublicationType.Text;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PublicationType.Type_].Value = Converter.StringToDataBox(textBoxPublicationType.Text);
                    Database.SaveChanges(Database.publicationTypes[dataGridViewMain.SelectedCells[0].RowIndex], publicationType);
                    break;
                case Table.PrintingHouse:
                    PrintingHouse printingHouse = new PrintingHouse();
                    printingHouse.Id = Converter.StringToInt(textBox_PH_ID.Text);
                    printingHouse.Name = textBox_PH_Name.Text;
                    printingHouse.Address = richTextBox_PH_Address.Text;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PrintingHouse.Id_].Value = Converter.StringToDataBox(textBox_PH_ID.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PrintingHouse.Name_].Value = Converter.StringToDataBox(textBox_PH_Name.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[PrintingHouse.Address_].Value = Converter.StringToDataBox(richTextBox_PH_Address.Text);
                    Database.SaveChanges(Database.printingHouses[dataGridViewMain.SelectedCells[0].RowIndex], printingHouse);
                    break;
                case Table.Login:
                    Login login = new Login();
                    login.Id = Converter.StringToInt(comboBox_Login_IDPH.SelectedItem?.ToString());
                    login.Username = textBox_Login_Username.Text;
                    login.Password = textBox_Login_Password.Text;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Login.Id_].Value = Converter.StringToDataBox(comboBox_Login_IDPH.SelectedItem?.ToString());
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Login.Username_].Value = Converter.StringToDataBox(textBox_Login_Username.Text);
                    dataGridViewMain.Rows[dataGridViewMain.SelectedCells[0].RowIndex].Cells[Login.Password_].Value = Converter.StringToDataBox(textBox_Login_Password.Text);
                    Database.SaveChanges(Database.logins[dataGridViewMain.SelectedCells[0].RowIndex], login);
                    break;
                    //TODO: add representative
            }
            buttonSaveChanges.Enabled = false;
        }   

        private void ValueChanged(object sender, EventArgs e)
        {
            buttonSaveChanges.Enabled = true;
        }

        private void order_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.PublishingOrder;
            HideBoxes();
            ClearData();
            groupBoxOrder.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            LoadDataGridView(dataGridViewAdd1, Table.Publication, labelAddData1);
            LoadDataGridView(dataGridViewAdd2, Table.Representative, labelAddData2);
            LoadDataGridView(dataGridViewAdd3, Table.PrintingHouse, labelAddData3);

            comboBox_Order_IDPH.Items.Clear();
            Database.printingHouses.ForEach(x => comboBox_Order_IDPH.Items.Add(x.Id.ToString()));
            comboBox_Order_IDPublication.Items.Clear();
            Database.publications.ForEach(x => comboBox_Order_IDPublication.Items.Add(x.Id.ToString()));
            comboBox_Order_IDRepres.Items.Clear();
            Database.representatives.ForEach(x => comboBox_Order_IDRepres.Items.Add(x.Id.ToString()));
            comboBox_Order_Status.Items.Clear();
            OrderStatusHelper.GetList().ForEach(x => comboBox_Order_Status.Items.Add(x));
            LoadBox();
        }

        private void publication_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Publication;
            HideBoxes();
            ClearData();
            ClearLabels();
            groupBoxPublication.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);

            comboBox_Publication_Type.Items.Clear();
            Database.publicationTypes.ForEach(x => comboBox_Publication_Type.Items.Add(x.Type));
            LoadBox();
        }

        private void representative_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Representative;
            HideBoxes();
            ClearData();
            ClearLabels();
            groupBoxRepresentative.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            LoadBox();
        }

        private void person_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Person;
            HideBoxes();
            ClearData();
            ClearLabels();
            groupBoxPerson.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            LoadBox();
        }

        private void author_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Author;
            HideBoxes();
            ClearData();
            groupBoxAuthor.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);

            comboBox_Author_ID.Items.Clear();
            Database.persons.ForEach(x => comboBox_Author_ID.Items.Add(x.Id.ToString()));
            LoadBox();
        }

        private void authorship_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Authorship;
            HideBoxes();
            ClearData();
            groupBoxAuthorship.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);

            comboBox_Authorship_IDAuthor.Items.Clear();
            Database.authors.ForEach(x => comboBox_Authorship_IDAuthor.Items.Add(x.Id.ToString()));
            comboBox_Authorship_IDPublication.Items.Clear();
            Database.publications.ForEach(x => comboBox_Authorship_IDPublication.Items.Add(x.Id.ToString()));
            LoadBox();

        }

        private void entity_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Entity;
            HideBoxes();
            ClearData();
            groupBoxEntity.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            LoadBox();
        }

        private void publicationType_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.PublicationType;
            HideBoxes();
            ClearData();
            groupBoxPublicationType.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            LoadBox();
        }

        private void printingHouse_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.PrintingHouse;
            HideBoxes();
            ClearData();
            groupBoxPrintingHouse.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            LoadBox();
        }

        private void login_mmi_Click(object sender, EventArgs e)
        {
            Session.Table = Table.Login;
            HideBoxes();
            ClearData();
            groupBoxLogin.Visible = true;
            LoadDataGridView(dataGridViewMain, Session.Table, labelMainData);
            comboBox_Login_IDPH.Items.Clear();
            Database.printingHouses.ForEach(x => comboBox_Login_IDPH.Items.Add(x.Id.ToString()));
            LoadBox();
        }

        private void ClearLabels()
        {
            labelMainData.Text = "";
            labelAddData1.Text = "";
            labelAddData2.Text = "";
            labelAddData3.Text = "";
        }
    }
}
