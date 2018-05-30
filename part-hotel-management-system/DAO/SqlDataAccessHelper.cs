using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAO
{
    public class SqlDataAccessHelper
    {
        #region ConnectionString
        private static String ReadConnectionString(String fileName)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(fileName);
            }
            catch (Exception)
            {

                throw;
            }

            XmlElement root = doc.DocumentElement;
            String connString = root.InnerText;
            return connString;
        }

        public static String ConnectionString()
        {
            return ReadConnectionString("..\\..\\..\\ConnectionString.xml");
        }
        #endregion

    }
}
