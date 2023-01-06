using PublishingHouse.Constants;
using PublishingHouse.Helpers;
using PublishingHouse.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishingHouse
{
    public static class Database
    {
        private static SqlConnection connection;
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
                string query;
                SqlCommand command;
                SqlDataReader rdr;

                query = "select * from Login";
                command = new SqlCommand(query, connection);
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        Login login = new Login();
                        login.Id = (!String.IsNullOrEmpty(rdr[Login.Id_].ToString())) ? int.Parse(rdr[Login.Id_].ToString()) : 0;
                        login.Username = (!String.IsNullOrEmpty(rdr[Login.Username_].ToString())) ? rdr[Login.Username_].ToString() : null;
                        login.Password = (!String.IsNullOrEmpty(rdr[Login.Password_].ToString())) ? rdr[Login.Password_].ToString() : null;
                        logins.Add(login);
                    }
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
                        publishingOrder.DateOrder = (!String.IsNullOrEmpty(rdr[PublishingOrder.DateOrder_].ToString())) ? DateTime.Parse(rdr[PublishingOrder.DateOrder_].ToString()) : new DateTime();
                        publishingOrder.DateCompliting = (!String.IsNullOrEmpty(rdr[PublishingOrder.DateCompliting_].ToString())) ? DateTime.Parse(rdr[PublishingOrder.DateCompliting_].ToString()) : new DateTime();
                        publishingOrder.Status = (!String.IsNullOrEmpty(rdr[PublishingOrder.OrderStatus_].ToString())) ? OrderStatusHelper.StringToEnum(rdr[PublishingOrder.OrderStatus_].ToString()) : OrderStatus.Unknown;
                        publishingOrder.PrintingCount = (!String.IsNullOrEmpty(rdr[PublishingOrder.PrintingCount_].ToString())) ? int.Parse(rdr[PublishingOrder.PrintingCount_].ToString()) : 0;
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

        public static bool SaveToDatabase(object old, object update)
        {
            try
            {
                if (update.GetType() == typeof(Person))
                {
                    Person t = (Person)update;
                    int index = persons.IndexOf((Person)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    //                CascadeUpdate(persons[index], update);
                    if (DoesExists($"SELECT * FROM Person WHERE {Person.Id_} = {Converter.IntToString(persons[index].Id)}"))
                        DoCommand($"UPDATE Person " +
                        $"SET {Person.Id_} = {Converter.IntToString(t.Id)}, " +
                        $"{Person.Name_} = {Converter.StringToDatabase(t.Name)}, " +
                        $"{Person.Address_} = {Converter.StringToDatabase(t.Address)}, " +
                        $"{Person.Phone_} = {Converter.StringToDatabase(t.Phone)} " +
                        $"WHERE {Person.Id_} = {Converter.IntToString(persons[index].Id)}");
                    else
                        DoCommand($"INSERT INTO Person ({Person.Id_}, {Person.Name_}, {Person.Address_}, {Person.Phone_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.StringToDatabase(t.Name)}, " +
                        $"{Converter.StringToDatabase(t.Address)}, " +
                        $"{Converter.StringToDatabase(t.Phone)})");
                    persons[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(Entity))
                {
                    Entity t = (Entity)update;
                    int index = entities.IndexOf((Entity)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM Entity WHERE {Entity.Id_} = {Converter.IntToString(entities[index].Id)}"))
                        DoCommand($"UPDATE Entity " +
                        $"SET {Entity.Id_} = {Converter.IntToString(t.Id)}, " +
                        $"{Entity.Name_} = {Converter.StringToDatabase(t.Name)} " +
                        $"WHERE {Entity.Id_} = {Converter.IntToString(entities[index].Id)}");
                    else
                        DoCommand($"INSERT INTO Entity ({Entity.Id_}, {Entity.Name_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.StringToDatabase(t.Name)})");
                    entities[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(Publication))
                {
                    Publication t = (Publication)update;
                    int index = publications.IndexOf((Publication)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM Publication WHERE {Publication.Id_} = {Converter.IntToString(publications[index].Id)}"))
                        DoCommand($"UPDATE Publication " +
                        $"SET {Publication.Id_} = {Converter.IntToString(t.Id)}, " +
                        $"{Publication.Name_} = {Converter.StringToDatabase(t.Name)}, " +
                        $"{Publication.Type_} = {Converter.StringToDatabase(t.Type)}, " +
                        $"{Publication.Size_} = {Converter.IntToString(t.Size)} " +
                        $"WHERE {Publication.Id_} = {Converter.IntToString(publications[index].Id)}");
                    else
                        DoCommand($"INSERT INTO Publication ({Publication.Id_}, {Publication.Name_}, {Publication.Type_}, {Publication.Size_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.StringToDatabase(t.Name)}, " +
                        $"{Converter.StringToDatabase(t.Type)}, " +
                        $"{Converter.IntToString(t.Size)})");
                    publications[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(PublicationType))
                {
                    PublicationType t = (PublicationType)update;
                    int index = publicationTypes.IndexOf((PublicationType)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM PublicationType WHERE {PublicationType.Type_} = {Converter.StringToDatabase(publicationTypes[index].Type)}"))
                        DoCommand($"UPDATE PublicationType " +
                        $"SET {PublicationType.Type_} = {Converter.StringToDatabase(t.Type)} " +
                        $"WHERE {PublicationType.Type_} = {Converter.StringToDatabase(publicationTypes[index].Type)}");
                    else
                        DoCommand($"INSERT INTO PublicationType ({PublicationType.Type_}) " +
                        $"VALUES ({Converter.StringToDatabase(t.Type)})");
                    publicationTypes[index].Type = t.Type;
                    return true;
                }
                if (update.GetType() == typeof(Login))
                {
                    Login t = (Login)update;
                    int index = logins.IndexOf((Login)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM Login WHERE {Login.Id_} = {Converter.IntToString(logins[index].Id)}"))
                        DoCommand($"UPDATE Login " +
                        $"SET {Login.Id_} = {Converter.IntToString(t.Id)}," +
                        $"{Login.Username_} = {Converter.StringToDatabase(t.Username)}, " +
                        $"{Login.Password_} = {Converter.StringToDatabase(t.Password)} " +
                        $"WHERE {Login.Id_} = {Converter.IntToString(logins[index].Id)}");
                    else
                        DoCommand($"INSERT INTO Login ({Login.Id_}, {Login.Username_}, {Login.Password_}) " +
                        $"VALUES({Converter.IntToString(t.Id)}, " +
                        $"{Converter.StringToDatabase(t.Username)}, " +
                        $"{Converter.StringToDatabase(t.Password)}) ");
                    logins[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(Author))
                {
                    Author t = (Author)update;
                    int index = authors.IndexOf((Author)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM Author WHERE {Author.Id_} = {Converter.IntToString(authors[index].Id)}"))
                        DoCommand($"UPDATE Author " +
                        $"SET {Author.Id_} = {Converter.IntToString(t.Id)}, " +
                        $"{Author.AdditionalInfo_} = {Converter.StringToDatabase(t.AdditionalInfo)} " +
                        $"WHERE {Author.Id_} = {Converter.IntToString(authors[index].Id)}");
                    else
                        DoCommand($"INSERT INTO Author ({Author.Id_}, {Author.AdditionalInfo_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.StringToDatabase(t.AdditionalInfo)})");
                    authors[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(Authorship))
                {
                    Authorship t = (Authorship)update;
                    int index = authorships.IndexOf((Authorship)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM Authorship WHERE {Authorship.IdAuthor_} = {Converter.IntToString(authorships[index].IdAuthor)} and {Authorship.IdPublication_} = {Converter.IntToString(authorships[index].IdPublication)}"))
                        DoCommand($"UPDATE Authorship " +
                        $"SET {Authorship.IdAuthor_} = {Converter.IntToString(t.IdAuthor)}," +
                        $"{Authorship.IdPublication_} = {Converter.IntToString(t.IdPublication)}" +
                        $"WHERE {Authorship.IdAuthor_} = {Converter.IntToString(authorships[index].IdAuthor)} and " +
                        $"{Authorship.IdPublication_} = {Converter.IntToString(authorships[index].IdPublication)}");
                    else
                        DoCommand($"INSERT INTO Authorship ({Authorship.IdAuthor_}, {Authorship.IdPublication_}) " +
                        $"VALUES ({Converter.IntToString(t.IdAuthor)}, " +
                        $"{Converter.IntToString(t.IdPublication)})");
                    authorships[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(PrintingHouse))
                {
                    PrintingHouse t = (PrintingHouse)update;
                    int index = printingHouses.IndexOf((PrintingHouse)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    //                CascadeCheck(old, t);
                    if (DoesExists($"SELECT * FROM PrintingHouse WHERE {PrintingHouse.Id_} = {Converter.IntToString(printingHouses[index].Id)}"))
                        DoCommand($"UPDATE PrintingHouse " +
                        $"SET {PrintingHouse.Id_} = {Converter.IntToString(t.Id)}, " +
                        $"{PrintingHouse.Name_} = {Converter.StringToDatabase(t.Name)}, " +
                        $"{PrintingHouse.Address_} = {Converter.StringToDatabase(t.Address)} " +
                        $"WHERE {PrintingHouse.Id_} = {Converter.IntToString(printingHouses[index].Id)}");
                    else
                        DoCommand($"INSERT INTO PrintingHouse ({PrintingHouse.Id_}, {PrintingHouse.Name_}, {PrintingHouse.Address_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.StringToDatabase(t.Name)}, " +
                        $"{Converter.StringToDatabase(t.Address)}) ");
                    printingHouses[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(PublishingOrder))
                {
                    PublishingOrder t = (PublishingOrder)update;
                    int index = publishingOrders.IndexOf((PublishingOrder)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM PublishingOrder WHERE {PublishingOrder.Id_} = {Converter.IntToString(publishingOrders[index].Id)}"))
                        DoCommand($"UPDATE PublishingOrder " +
                        $"SET {PublishingOrder.Id_} = {Converter.IntToString(t.Id)}, " +
                        $"{PublishingOrder.IdPublication_} = {Converter.IntToString(t.IdPublication)}, " +
                        $"{PublishingOrder.IdPrintingHouse_} = {Converter.IntToString(t.IdPrintingHouse)}, " +
                        $"{PublishingOrder.IdRepresentative_} = {Converter.IntToString(t.IdRepresentative)}, " +
                        $"{PublishingOrder.DateOrder_} = {Converter.DateTimeToDatabase(t.DateOrder)}, " +
                        $"{PublishingOrder.DateCompliting_} = {Converter.DateTimeToDatabase(t.DateCompliting)}, " +
                        $"{PublishingOrder.OrderStatus_} = {Converter.StringToDatabase(OrderStatusHelper.EnumToString(t.Status))}, " +
                        $"{PublishingOrder.PrintingCount_} = {Converter.IntToString(t.PrintingCount)} " +
                        $"WHERE {PublishingOrder.Id_} = {Converter.IntToString(publishingOrders[index].Id)}");
                    else
                        DoCommand($"INSERT INTO PublishingOrder ({PublishingOrder.Id_}, {PublishingOrder.IdPublication_}, {PublishingOrder.IdPrintingHouse_}, {PublishingOrder.IdRepresentative_}, {PublishingOrder.DateOrder_}, {PublishingOrder.DateCompliting_}, {PublishingOrder.OrderStatus_}, {PublishingOrder.PrintingCount_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.IntToString(t.IdPublication)}, " +
                        $"{Converter.IntToString(t.IdPrintingHouse)}, " +
                        $"{Converter.IntToString(t.IdRepresentative)}, " +
                        $"{Converter.DateTimeToDatabase(t.DateOrder)}, " +
                        $"{Converter.DateTimeToDatabase(t.DateCompliting)}, " +
                        $"{Converter.StringToDatabase(OrderStatusHelper.EnumToString(t.Status))}, " +
                        $"{Converter.IntToString(t.PrintingCount)})");
                    publishingOrders[index] = t;
                    return true;
                }
                if (update.GetType() == typeof(Representative))
                {
                    Representative t = (Representative)update;
                    int index = representatives.IndexOf((Representative)old);
                    if (index == -1) throw new Exception("Didn't find item");
                    if (DoesExists($"SELECT * FROM Representative WHERE {Representative.Id_} = {Converter.IntToString(representatives[index].Id)}"))
                        DoCommand($"UPDATE Representative " +
                        $"SET {Representative.Id_} = {Converter.IntToString(t.Id)}," +
                        $"{Representative.IdEntity_} = {Converter.IntToString(t.IdEntity)}," +
                        $"{Representative.IdAuthor_} = {Converter.IntToString(t.IdAuthor)} " +
                        $"WHERE {Representative.Id_} = {Converter.IntToString(representatives[index].Id)}");
                    else
                        DoCommand($"INSERT INTO Representative ({Representative.Id_}, {Representative.IdEntity_}, {Representative.IdAuthor_}) " +
                        $"VALUES ({Converter.IntToString(t.Id)}, " +
                        $"{Converter.IntToString(t.IdEntity)}, " +
                        $"{Converter.IntToString(t.IdAuthor)}) ");
                    representatives[index] = t;
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public static bool DeleteFromDatabase(object obj)
        {
            try
            {
                if (obj.GetType() == typeof(Person))
                {
                    Person t = (Person)obj;
                    DoCommand($"DELETE FROM Person " +
                        $"WHERE {Person.Id_} = {Converter.IntToString(t.Id)}");
                    persons.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(Entity))
                {
                    Entity t = (Entity)obj;
                    DoCommand($"DELETE FROM Entity " +
                        $"WHERE {Entity.Id_} = {Converter.IntToString(t.Id)}");
                    entities.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(Publication))
                {
                    Publication t = (Publication)obj;
                    DoCommand($"DELETE FROM Publication " +
                        $"WHERE {Publication.Id_} = {Converter.IntToString(t.Id)}");
                    publications.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(PublicationType))
                {
                    PublicationType t = (PublicationType)obj;
                    DoCommand($"DELETE FROM PublicationType " +
                        $"WHERE {PublicationType.Type_} = {Converter.StringToDatabase(t.Type)}");
                    publicationTypes.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(Login))
                {
                    Login t = (Login)obj;
                    DoCommand($"DELETE FROM Login " +
                        $"WHERE {Login.Id_} = {Converter.IntToString(t.Id)}");
                    logins.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(Author))
                {
                    Author t = (Author)obj;
                    DoCommand($"DELETE FROM Author " +
                        $"WHERE {Author.Id_} = {Converter.IntToString(t.Id)}");
                    authors.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(Authorship))
                {
                    Authorship t = (Authorship)obj;
                    DoCommand($"DELETE FROM Authorship " +
                        $"WHERE {Authorship.IdAuthor_} = {Converter.IntToString(t.IdAuthor)} and " +
                        $"{Authorship.IdPublication_} = {Converter.IntToString(t.IdPublication)}");
                    authorships.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(PrintingHouse))
                {
                    PrintingHouse t = (PrintingHouse)obj;
                    DoCommand($"DELETE FROM PrintingHouse " +
                        $"WHERE {PrintingHouse.Id_} = {Converter.IntToString(t.Id)}");
                    printingHouses.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(PublishingOrder))
                {
                    PublishingOrder t = (PublishingOrder)obj;
                    DoCommand($"DELETE FROM PublishingOrder " +
                        $"WHERE {PublishingOrder.Id_} = {Converter.IntToString(t.Id)}");
                    publishingOrders.Remove(t);
                    return true;
                }
                if (obj.GetType() == typeof(Representative))
                {
                    Representative t = (Representative)obj;
                    DoCommand($"DELETE FROM Representative " +
                        $"WHERE {Representative.Id_} = {Converter.IntToString(t.Id)}");
                    representatives.Remove(t);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        private static void DoCommand(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            MessageBox.Show($"{command.ExecuteNonQuery()} rows has been affected");
        }

        private static bool DoesExists(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader rdr = command.ExecuteReader();
            bool result = rdr.HasRows;
            rdr.Close();
            return result;
        }

        public static Dictionary<string, int> GetAuthorStatistics()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            SqlCommand command = new SqlCommand("select Person.NamePerson, SUM(PrintingCount) as summ\r\n" +
                "from PublishingOrder, Publication, Authorship, Author, Person\r\n" +
                "where PublishingOrder.ID_Publication = Publication.ID_Publication and Publication.ID_Publication = Authorship.ID_Publication and \r\n" +
                "Authorship.ID_Author = Author.ID_Author and Author.ID_Author = Person.ID_Person\r\n" +
                "group by Person.NamePerson", connection);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.HasRows)
                while (rdr.Read())
                {
                    result.Add(rdr[Person.Name_].ToString(), int.Parse(rdr["summ"].ToString()));
                }
            rdr.Close();
            return result;
        }

        public static Dictionary<string, int> GetPrintingHouseStatistics()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            SqlCommand command = new SqlCommand("select PrintingHouse.NamePrintingHouse, COUNT(*) as cou\r\n" +
                "from PrintingHouse, PublishingOrder\r\n" +
                "where PrintingHouse.ID_PrintingHouse = PublishingOrder.ID_PrintingHouse\r\n" +
                "group by PrintingHouse.NamePrintingHouse", connection);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.HasRows)
                while (rdr.Read())
                {
                    result.Add(rdr[PrintingHouse.Name_].ToString(), int.Parse(rdr["cou"].ToString()));
                }
            rdr.Close();
            return result;
        }
    }
}
