using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Upload_Client
{
    class API_functions
    {
        
        public static string Login(string user_name, string password)
        {
            
            var uri = new Uri("https://serhiy-ivanochko.quatrix.it/api/1.0/session/login");
            WebRequest request = WebRequest.Create(uri);
            string credentials = user_name + ":" + password;
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            
            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();

            var current_obj = JObject.Parse(content);

            return (string)current_obj["session_id"];
            
        }
        //public static string Authorization(string session_id)
        //{
        //    var uri = new Uri("https://api.quatrix.it/api/1.0/session/keepalive");
        //    WebRequest request = WebRequest.Create(uri);
        //    request.Headers["X-Auth-Token"] = session_id;
        //    WebResponse wr = request.GetResponse();
        //    Stream receiveStream = wr.GetResponseStream();
        //    StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
        //    string content = reader.ReadToEnd();

        //    return session_id;
        //}
        public static string Upload(string file_name, int id_cat, string session_id)
        {


            User user = User_id(session_id);



            var uri = new Uri("https://serhiy-ivanochko.quatrix.it/api/1.0/upload/link/");
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "multipart/form-data";
            request.Headers["X-Auth-Token"] = session_id;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                Upload_File u = new Upload_File();
                u.name = "37198.bin";
                u.parent_id = user.home_id;
                u.resolve = true;

                string json = JsonConvert.SerializeObject(u);

                streamWriter.Write(json);

                //byte[] bytes = System.IO.File.ReadAllBytes(@"C:\FileGenerator\37198.bin");

                //json = JsonConvert.SerializeObject(bytes);

                //streamWriter.Write(json);
            }

            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();

            var current_obj = JObject.Parse(content);

            //return Finalize_upload((string)current_obj["upload_key"], session_id);

             uri = new Uri("https://serhiy-ivanochko.quatrix.it/api/1.0/upload/chunked/"+ (string)current_obj["upload_key"]);
            HttpClient httpClient = new HttpClient();

            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Headers.Add("X-Auth-Token", session_id);
            FileStream fs = File.OpenRead(@"C:\FileGenerator\37198.bin");
            var streamContent = new StreamContent(fs);

            var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            form.Add(imageContent, "image", Path.GetFileName(@"C:\FileGenerator\37198.bin"));
            var response = httpClient.PostAsync(uri, form).Result;

            return "";

        }

        public static string Finalize_upload(string upload_key, string session_id) {
            var uri = new Uri("https://serhiy-ivanochko.quatrix.it/api/1.0/upload/finalize/"+upload_key);
            WebRequest request = WebRequest.Create(uri);
            request.Headers["X-Auth-Token"] = session_id;

            

            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();

            var current_obj = JObject.Parse(content);
            return "";
        }
        public static User User_id(string session_id) {
            var uri = new Uri("https://serhiy-ivanochko.quatrix.it/api/1.0/user");
            WebRequest request = WebRequest.Create(uri);
            request.Headers["X-Auth-Token"] = session_id;
            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            JArray objects = JArray.Parse(content);
            User user = null;
            foreach (var current_obj in objects.Children())
            {
                user = new User(current_obj);
            }
            
            return user;
        }
        //public static string Root_dir(User user, string session_id)
        //{
        //    string value = "";
        //    var uri = new Uri("https://serhiy-ivanochko.quatrix.it/api/1.0/user");

        //    WebRequest request = WebRequest.Create(uri);

        //    request.Headers["X-Auth-Token"] = session_id;

        //    WebResponse wr = request.GetResponse();
        //    Stream receiveStream = wr.GetResponseStream();
        //    StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
        //    string content = reader.ReadToEnd();
        //    return value;
        //}
    }
}
