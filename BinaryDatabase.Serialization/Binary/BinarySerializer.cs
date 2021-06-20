using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BinaryDatabase.Serialization.Binary
{
    public class BinarySerializer {
        public void Serialize(Object obj, string filePathName)
        {
            FileStream fs = new FileStream(filePathName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public Object Deserialize(string filePathName)
        {
            Object returnObj = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(filePathName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // assign the reference to the local variable.
                returnObj = (Object)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return returnObj;
        }
    }
}
