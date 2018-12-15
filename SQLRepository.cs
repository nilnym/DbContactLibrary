using DbContactLibrary.Entities;
using DbContactLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DbContactLibrary
{
    public static class SQLRepository
    {
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=DbContact;Integrated Security=True;
                                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Contact
        public static int CreateContact(string ssn, string firstName, string lastName)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "INSERT INTO Contact OUTPUT INSERTED.ID VALUES (@ssn, @firstName, @lastName)";

            command.Parameters.AddWithValue("@ssn", ssn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            return CreateRecord(command);
        }

        public static Contact ReadContact(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM Contact WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return GetSingleObject(command, CreateContact);
        }

        public static List<Contact> ReadAllContacts()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM Contact";

            return GetListOfObjects(command, CreateContact);
        }

        public static bool UpdateContact(int id, string ssn, string firstName, string lastName)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "UPDATE Contact SET SSN = @ssn, FirstName = @firstName, LastName = @lastName WHERE ID = @id";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@ssn", ssn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            return ExecuteNonQuery(command);
        }

        public static bool DeleteContact(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "DELETE FROM Contact WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }
        #endregion

        #region Address
        public static int CreateAddress(string street, string city, string zip)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO Address OUTPUT INSERTED.ID VALUES (@street, @city, @zip)";

            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@zip", zip);

            return CreateRecord(command);
        }

        public static Address ReadAddress(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM Address WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return GetSingleObject(command, CreateAddress);
        }

        public static List<Address> ReadAllAddresses()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Address";

            return GetListOfObjects(command, CreateAddress);
        }

        public static bool UpdateAddress(int id, string street, string city, string zip)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE Address SET Street = @street, City = @city, Zip = @zip WHERE ID = @id";

            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@zip", zip);
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }

        public static bool DeleteAddress(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "DELETE FROM Address WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }
        #endregion

        #region Contact information
        public static int CreateContactInformation(string info, string contactId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO ContactInformation OUTPUT INSERTED.ID VALUES (@info, @contactid)";

            command.Parameters.AddWithValue("@info", info);
            command.Parameters.AddWithValue("@contactid", contactId);

            return CreateRecord(command);
        }

        public static ContactInformation ReadContactInformation(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM ContactInformation WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return GetSingleObject(command, CreateContactInformation);
        }

        public static List<ContactInformation> ReadAllContactInformation()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM ContactInformation";

            return GetListOfObjects(command, CreateContactInformation);
        }

        public static bool UpdateContactInformation(int id, string info, string contactId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE ContactInformation SET Info = @info, ContactId = @contactid WHERE ID = @id";

            command.Parameters.AddWithValue("@info", info);
            command.Parameters.AddWithValue("@contactid", contactId);
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }

        public static bool DeleteContactInformation(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "DELETE FROM ContactInformation WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }
        #endregion

        #region C2A
        public static int CreateContactToAddress(int contactId, int addressId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO C2A OUTPUT INSERTED.ID VALUES (@contactid, @addressid)";

            command.Parameters.AddWithValue("@contactid", contactId);
            command.Parameters.AddWithValue("@addressid", addressId);

            return CreateRecord(command);
        }

        public static C2A ReadContactToAddress(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM C2A WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return GetSingleObject(command, CreateContactToAddress);
        }

        public static List<C2A> ReadAllContactToAddress()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM C2A";

            return GetListOfObjects(command, CreateContactToAddress);
        }

        public static bool UpdateContactToAddress(int id, int cid, int aid)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "UPDATE C2A SET CID = @cid, AID = @aid WHERE ID = @id";
            command.Parameters.AddWithValue("@cid", cid);
            command.Parameters.AddWithValue("@aid", aid);
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }

        public static bool DeleteContactToAddress(int id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "DELETE FROM C2A WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return ExecuteNonQuery(command);
        }
        #endregion

        #region ContactEntity
        public static ContactEntity ReadContactEntity(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Contact WHERE ID = @id";
            command.Parameters.AddWithValue("@id", id);

            return GetSingleObject(command, CreateContactEntity);
        }

        // List<ContactEntity> ReadAllContactEntities()
        public static List<ContactEntity> ReadAllContactEntities()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Contact";

            return GetListOfObjects(command, CreateContactEntity);
        }
        #endregion

        #region Delegates
        static Contact CreateContact(SqlDataReader reader)
        {
            return new Contact
            {
                ID = (int)reader["ID"],
                SSN = (string)reader["SSN"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
            };
        }

        static Address CreateAddress(SqlDataReader reader)
        {
            return new Address
            {
                ID = (int)reader["ID"],
                Street = (string)reader["Street"],
                City = (string)reader["City"],
                Zip = (string)reader["Zip"],
            };
        }

        static ContactInformation CreateContactInformation(SqlDataReader reader)
        {
            return new ContactInformation
            {
                ContactID = reader["ContactId"] != null ? (int)reader["ContactId"] : (int?)null,
                Info = (string)reader["Info"],
                ID = (int)reader["ID"],
            };
        }

        static C2A CreateContactToAddress(SqlDataReader reader)
        {
            return new C2A
            {
                ID = (int)reader["ID"],
                AID = (int)reader["AID"],
                CID = (int)reader["CID"],
            };
        }

        static ContactEntity CreateContactEntity(SqlDataReader reader)
        {
            var contactId = (int)reader["ID"];

            var connections = ReadAllContactToAddress()
                .Where(a => a.CID == contactId)
                .ToList();

            var addresses = ReadAllAddresses()
                .Join(connections, a => a.ID,
                    c => c.AID, (a, c) => a)
                .ToList();

            var contactInformation = ReadAllContactInformation()
                .Where(i => i.ContactID == contactId)
                .ToList();

            return new ContactEntity
            {
                ID = contactId,
                SSN = (string)reader["SSN"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Addresses = addresses,
                ContactInformation = contactInformation,
            };
        }
        #endregion

        #region Generic
        static int CreateRecord(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;

                    return (int)command.ExecuteScalar();
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        static T GetSingleObject<T>(SqlCommand command, Func<SqlDataReader, T> createObject)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;

                    var reader = command.ExecuteReader();

                    reader.Read();

                    return createObject(reader);
                }
                catch
                {
                    return default(T);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        static List<T> GetListOfObjects<T>(SqlCommand command, Func<SqlDataReader, T> getObject)
        {
            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;

                    var reader = command.ExecuteReader();

                    var list = new List<T>();

                    while (reader.Read())
                    {
                        list.Add(getObject(reader));
                    }

                    return list;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        static bool ExecuteNonQuery(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    command.Connection = connection;

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion
    }
}