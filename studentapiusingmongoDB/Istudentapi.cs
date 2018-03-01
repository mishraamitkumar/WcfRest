using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace studentapiusingmongoDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Istudentapi" in both code and config file together.
    [ServiceContract]
    public interface Istudentapi
    {
        [OperationContract]
        //[XmlSerializerFormat]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, 
            Method = "POST",
            RequestFormat =WebMessageFormat.Json,           
            ResponseFormat = WebMessageFormat.Json
            //)]
            ,UriTemplate ="/addstudent")]
        void insertStudent(Student std);

        //http://localhost/studentapiusingmongoDB/studentapi.svc/getstudents
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getallstudents")]
        Task<List<Student>> getstudents();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getstudentbyrollno/{rollno}")]
        Task<string> getstudentbyrollnumber(string rollno);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
         Method = "GET",
         RequestFormat = WebMessageFormat.Xml,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/getstudentby/{propertyname}/{expression}")]
        Task<string> getstudentbycategory(string propertyname, string expression);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
        Method = "PUT",
        RequestFormat = WebMessageFormat.Xml,
        ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "/updatestudentbyrollno")]
        Task<string> updatestudentbyrollnumber(Student std);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
      Method = "DELETE",
      RequestFormat = WebMessageFormat.Xml,
      ResponseFormat = WebMessageFormat.Xml,
      UriTemplate = "/deletestudentbyrollno/{rollno}")]
        Task<string> deletestudentbyrollnumber(string rollno);


    }

    [DataContract]
    public class Student
    {
        //[DataMember]
        //public string Id{ get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string RollNo { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Address { get; set; }

    }
}
