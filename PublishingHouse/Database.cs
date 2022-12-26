using PublishingHouse.Constants;
using PublishingHouse.Helpers;
using PublishingHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishingHouse
{
    public static class Database
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        public static List<Person> persons = new List<Person>();
        public static List<Publication> publications = new List<Publication>();
        public static List<Login> logins = new List<Login>();
        public static List<Author> authors = new List<Author>();
        public static List<Authorship> authorships = new List<Authorship>();
        public static List<Entity> entities = new List<Entity>();
        public static List<PrintingHouse> printingHouses = new List<PrintingHouse>();
        public static List<PublicationType> publicationTypes = new List<PublicationType>();
        public static List<PublishingOrder> publishingOrders = new List<PublishingOrder>();
        public static List<Representative> representatives = new List<Representative>();
        static Database()
        {
            try
            {
                connection = new SqlConnection(@"Data Source = LAPTOP-L72QCV1R; Initial Catalog = PublishingHouse; Integrated security = true;");
                connection.Open();

                string query = "select * from Login";
                command = new SqlCommand(query, connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Login login = new Login();
                        login.Id = (!String.IsNullOrEmpty(rdr[Login.Id_].ToString())) ? int.Parse(rdr[Login.Id_].ToString()) : 0;
                        login.Username = (!String.IsNullOrEmpty(rdr[Login.Username_].ToString())) ? rdr[Login.Username_].ToString() : null;
                        login.Password = (!String.IsNullOrEmpty(rdr[Login.Password_].ToString())) ? rdr[Login.Password_].ToString() : null;
                        logins.Add(login);
                    }
                logins.Add(new Login(0, "admin", "admin"));
                rdr.Close();

                query = "select * from Person";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Person person = new Person();
                        person.Id = (!String.IsNullOrEmpty(rdr[Person.Id_].ToString())) ? int.Parse(rdr[Person.Id_].ToString()) : 0;
                        person.Name = (!String.IsNullOrEmpty(rdr[Person.Name_].ToString())) ? rdr[Person.Name_].ToString() : null;
                        person.Address = (!String.IsNullOrEmpty(rdr[Person.Address_].ToString())) ? rdr[Person.Address_].ToString() : null;
                        person.Phone = (!String.IsNullOrEmpty(rdr[Person.Phone_].ToString())) ? rdr[Person.Phone_].ToString() : null;
                        persons.Add(person);
                    }
                rdr.Close();

                query = "select * from Publication";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Publication publication = new Publication();
                        publication.Id = (!String.IsNullOrEmpty(rdr[Publication.Id_].ToString())) ? int.Parse(rdr[Publication.Id_].ToString()) : 0;
                        publication.Name = (!String.IsNullOrEmpty(rdr[Publication.Name_].ToString())) ? rdr[Publication.Name_].ToString() : null;
                        publication.Type = (!String.IsNullOrEmpty(rdr[Publication.Type_].ToString())) ? rdr[Publication.Type_].ToString() : null;
                        publication.Size = (!String.IsNullOrEmpty(rdr[Publication.Size_].ToString())) ? int.Parse(rdr[Publication.Size_].ToString()) : 0;
                        publication.PrintingCount = (!String.IsNullOrEmpty(rdr[Publication.PrintingCount_].ToString())) ? int.Parse(rdr[Publication.PrintingCount_].ToString()) : 0;
                        publications.Add(publication);
                    }
                rdr.Close();

                query = "select * from Author";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Author author = new Author();
                        author.Id = (!String.IsNullOrEmpty(rdr[Author.Id_].ToString())) ? int.Parse(rdr[Author.Id_].ToString()) : 0;
                        author.AdditionalInfo = (!String.IsNullOrEmpty(rdr[Author.AdditionalInfo_].ToString())) ? rdr[Author.AdditionalInfo_].ToString() : null;
                        authors.Add(author);
                    }
                rdr.Close();

                query = "select * from Authorship";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Authorship authorship = new Authorship();
                        authorship.IdAuthor = (!String.IsNullOrEmpty(rdr[Authorship.IdAuthor_].ToString())) ? int.Parse(rdr[Authorship.IdAuthor_].ToString()) : 0;
                        authorship.IdPublication = (!String.IsNullOrEmpty(rdr[Authorship.IdPublication_].ToString())) ? int.Parse(rdr[Authorship.IdPublication_].ToString()) : 0;
                        authorships.Add(authorship);
                    }
                rdr.Close();

                query = "select * from Entity";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Entity entity = new Entity();
                        entity.Id = (!String.IsNullOrEmpty(rdr[Entity.Id_].ToString())) ? int.Parse(rdr[Entity.Id_].ToString()) : 0;
                        entity.Name = (!String.IsNullOrEmpty(rdr[Entity.Name_].ToString())) ? rdr[Entity.Name_].ToString() : null;
                        entities.Add(entity);
                    }
                rdr.Close();

                query = "select * from PrintingHouse";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        PrintingHouse printingHouse = new PrintingHouse();
                        printingHouse.Id = (!String.IsNullOrEmpty(rdr[PrintingHouse.Id_].ToString())) ? int.Parse(rdr[PrintingHouse.Id_].ToString()) : 0;
                        printingHouse.Name = (!String.IsNullOrEmpty(rdr[PrintingHouse.Name_].ToString())) ? rdr[PrintingHouse.Name_].ToString() : null;
                        printingHouse.Address = (!String.IsNullOrEmpty(rdr[PrintingHouse.Address_].ToString())) ? rdr[PrintingHouse.Address_].ToString() : null;
                        printingHouses.Add(printingHouse);
                    }
                rdr.Close();

                query = "select * from PublicationType";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        PublicationType publicationType = new PublicationType();
                        publicationType.Type = (!String.IsNullOrEmpty(rdr[PublicationType.Type_].ToString())) ? rdr[PublicationType.Type_].ToString() : null;
                        publicationTypes.Add(publicationType);
                    }
                rdr.Close();

                query = "select * from PublishingOrder";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        PublishingOrder publishingOrder = new PublishingOrder();
                        publishingOrder.Id = (!String.IsNullOrEmpty(rdr[PublishingOrder.Id_].ToString())) ? int.Parse(rdr[PublishingOrder.Id_].ToString()) : 0;
                        publishingOrder.IdPublication = (!String.IsNullOrEmpty(rdr[PublishingOrder.IdPublication_].ToString())) ? int.Parse(rdr[PublishingOrder.IdPublication_].ToString()) : 0;
                        publishingOrder.IdPrintingHouse = (!String.IsNullOrEmpty(rdr[PublishingOrder.IdPrintingHouse_].ToString())) ? int.Parse(rdr[PublishingOrder.IdPrintingHouse_].ToString()) : 0;
                        publishingOrder.IdRepresentative = (!String.IsNullOrEmpty(rdr[PublishingOrder.IdRepresentative_].ToString())) ? int.Parse(rdr[PublishingOrder.IdRepresentative_].ToString()) : 0;
                        publishingOrder.DateOrder = (!String.IsNullOrEmpty(rdr[PublishingOrder.DateOrder_].ToString())) ? DateTime.Parse (rdr[PublishingOrder.DateOrder_].ToString()) : new DateTime();
                        publishingOrder.DateCompliting = (!String.IsNullOrEmpty(rdr[PublishingOrder.DateCompliting_].ToString())) ? DateTime.Parse(rdr[PublishingOrder.DateCompliting_].ToString()) : new DateTime();
                        publishingOrder.Status = (!String.IsNullOrEmpty(rdr[PublishingOrder.OrderStatus_].ToString())) ? OrderStatusHelper.StringToEnum(rdr[PublishingOrder.OrderStatus_].ToString()) : OrderStatus.Unknown;
                        publishingOrders.Add(publishingOrder);
                    }
                rdr.Close();

                query = "select * from Representative";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Representative representative = new Representative();
                        representative.Id = (!String.IsNullOrEmpty(rdr[Representative.Id_].ToString())) ? int.Parse(rdr[Representative.Id_].ToString()) : 0;
                        representative.IdEntity = (!String.IsNullOrEmpty(rdr[Representative.IdEntity_].ToString())) ? int.Parse(rdr[Representative.IdEntity_].ToString()) : 0;
                        representative.IdAuthor = (!String.IsNullOrEmpty(rdr[Representative.IdAuthor_].ToString())) ? int.Parse(rdr[Representative.IdAuthor_].ToString()) : 0;
                        representatives.Add(representative);
                    }
                rdr.Close();
            }
            catch (Exception e) 
            {
                MessageBox.Show("Error while loading database\n" + e.ToString());
            }
        }

        public static void SaveChangesInLocal(DataGridView dataGridView)
        {
            try
            {
                switch (Session.Table)
                {
                    case Table.Person:
                        persons.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Person person = new Person();
                            person.Id = Converter.StringToInt(item.Cells[Person.Id_].Value?.ToString());
                            person.Name = Converter.DataToString(item.Cells[Person.Name_].Value?.ToString());
                            person.Address = Converter.DataToString(item.Cells[Person.Address_].Value?.ToString());
                            person.Phone = Converter.DataToString(item.Cells[Person.Phone_].Value?.ToString());
                            persons.Add(person);
                        }
                        break;
                    case Table.Entity:
                        entities.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Entity entity = new Entity();
                            entity.Id = (item.Cells[Entity.Id_].Value != null) ? int.Parse(item.Cells[Entity.Id_].Value.ToString()) : 0;
                            entity.Name = item.Cells[Entity.Name_].Value?.ToString();
                            entities.Add(entity);
                        }
                        break;
                    case Table.Publication:
                        publications.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Publication publication = new Publication();
                            publication.Id = (item.Cells[Publication.Id_].Value != null) ? int.Parse(item.Cells[Publication.Id_].Value.ToString()) : 0;
                            publication.Name = item.Cells[Publication.Name_].Value?.ToString();
                            publication.Type = item.Cells[Publication.Type_].Value?.ToString();
                            publication.Size = (item.Cells[Publication.Size_].Value != null) ? int.Parse(item.Cells[Publication.Size_].Value.ToString()) : 0;
                            publication.PrintingCount = (item.Cells[Publication.PrintingCount_].Value != null) ? int.Parse(item.Cells[Publication.PrintingCount_].Value.ToString()) : 0;
                            publications.Add(publication);
                        }
                        break;
                    case Table.PublicationType:
                        publicationTypes.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            PublicationType publicationType = new PublicationType();
                            publicationType.Type = item.Cells[PublicationType.Type_].Value?.ToString();
                            publicationTypes.Add(publicationType);
                        }
                        break;
                    case Table.Login:
                        logins.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Login login = new Login();
                            login.Id = (item.Cells[Login.Id_].Value != null) ? int.Parse(item.Cells[Login.Id_].Value.ToString()) : 0;
                            login.Username = item.Cells[Login.Username_].Value?.ToString();
                            login.Password = item.Cells[Login.Password_].Value?.ToString();
                            logins.Add(login);
                        }
                        break;
                    case Table.Author:
                        authors.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Author author = new Author();
                            author.Id = (item.Cells[Author.Id_].Value != null) ? int.Parse(item.Cells[Author.Id_].Value.ToString()) : 0;
                            author.AdditionalInfo = item.Cells[Author.AdditionalInfo_].Value?.ToString();
                            authors.Add(author);
                        }
                        break;
                    case Table.Authorship:
                        authorships.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Authorship authorship = new Authorship();
                            authorship.IdAuthor = (item.Cells[Authorship.IdAuthor_].Value != null) ? int.Parse(item.Cells[Authorship.IdAuthor_].Value.ToString()) : 0;
                            authorship.IdPublication = (item.Cells[Authorship.IdPublication_].Value != null) ? int.Parse(item.Cells[Authorship.IdPublication_].Value.ToString()) : 0;
                            authorships.Add(authorship);
                        }
                        break;
                    case Table.PrintingHouse:
                        printingHouses.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            PrintingHouse printingHouse = new PrintingHouse();
                            printingHouse.Id = (item.Cells[PrintingHouse.Id_].Value != null) ? int.Parse(item.Cells[PrintingHouse.Id_].Value.ToString()) : 0;
                            printingHouse.Name = item.Cells[PrintingHouse.Name_].Value?.ToString();
                            printingHouse.Address = item.Cells[PrintingHouse.Address_].Value?.ToString();
                            printingHouses.Add(printingHouse);
                        }
                        break;
                    case Table.PublishingOrder:
                        publishingOrders.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            PublishingOrder publishingOrder = new PublishingOrder();
                            publishingOrder.Id = Converter.StringToInt(item.Cells[PublishingOrder.Id_].Value?.ToString());
                            publishingOrder.IdPublication = Converter.StringToInt(item.Cells[PublishingOrder.IdPublication_].Value?.ToString());
                            publishingOrder.IdPrintingHouse = Converter.StringToInt(item.Cells[PublishingOrder.IdPrintingHouse_].Value?.ToString());
                            publishingOrder.IdRepresentative = Converter.StringToInt(item.Cells[PublishingOrder.IdRepresentative_].Value?.ToString());
                            publishingOrder.DateOrder = Converter.DataToDateTime(item.Cells[PublishingOrder.DateOrder_].Value?.ToString());
                            publishingOrder.DateCompliting = Converter.DataToDateTime(item.Cells[PublishingOrder.DateCompliting_].Value?.ToString());
                            publishingOrder.Status = OrderStatusHelper.StringToEnum(item.Cells[PublishingOrder.OrderStatus_].Value?.ToString());
                            publishingOrders.Add(publishingOrder);
                        }
                            break;
                    case Table.Representative:
                        representatives.Clear();
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            Representative representative = new Representative();
                            representative.Id = (item.Cells[Representative.Id_].Value != null) ? int.Parse(item.Cells[Representative.Id_].Value.ToString()) : 0;
                            representative.IdEntity = (item.Cells[Representative.IdEntity_].Value != null) ? int.Parse(item.Cells[Representative.IdEntity_].Value.ToString()) : 0;
                            representative.IdAuthor = (item.Cells[Representative.IdAuthor_].Value != null) ? int.Parse(item.Cells[Representative.IdAuthor_].Value.ToString()) : 0;
                            representatives.Add(representative);
                        }
                            break;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void SaveChangesToDatabase(DataGridView dataGridView)
        {
            switch (Session.Table)
            {

            }
        }
    }
}
