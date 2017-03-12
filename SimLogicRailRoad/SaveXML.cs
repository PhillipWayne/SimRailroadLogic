using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using testsim;

namespace testsim
{
    public class SaveXML
    {
        //This class saves the properties of a object in a file
      // This method passes two variables in. One is object which will contain the properties and filename which is the 
        // file where the properties will be stored 

        public static void SaveData  (object obj,string filename)
        {
            // This creates a instance of the class XmLSerializer Class 
            //The XmlSerializer class is used to serializes a object of a specified type in Xml docs.
            // That is why obj.Gettype is used caused the objects type is needed 
            
             XmlSerializer sr = new XmlSerializer(obj.GetType());
          
            //This Streamwriter takes the filename and passes to Textwriter  
             TextWriter writer = new StreamWriter(filename);
             // Serializes the object and xml doc is written to file with the text writer
             sr.Serialize(writer, obj);
            // This closes the class of the TextWriter
             writer.Close();
           
        }
    }
}
