using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ExerciseProgram.WebApp.Extentions
{
    public class HttpClientBase <T>
    {
        public T GetSingle(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ExerciseApiService"]);

                var responseTask = client.GetAsync(endPoint);

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    return result.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    throw new Exception($"Failed to get data from {endPoint}.");
                }
            }
        }
        public List<T> GetList(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ExerciseApiService"]);

                var responseTask = client.GetAsync(endPoint);

                responseTask.Wait();

                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                 
                    return result.Content.ReadAsAsync<List<T>>().Result;
                }
                else
                {
                    throw new Exception($"Failed to get data from {endPoint}.");
                }                
            }
        }

        public void Post(string endPoint, ObjectContent content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ExerciseApiService"]);

                var responseTask = client.PostAsync($"{endPoint}", content);

                responseTask.Wait();

                var result = responseTask.Result;

                if (!result.IsSuccessStatusCode)
                    throw new Exception($"Failed to post data to {endPoint}.");
            }
        }

        public void Put(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ExerciseApiService"]);

                var responseTask = client.PutAsync(endPoint, null);

                responseTask.Wait();

                var result = responseTask.Result;

                if (!result.IsSuccessStatusCode)
                    throw new Exception($"Failed to post data to {endPoint}.");
            }
        }

        public void Delete(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ExerciseApiService"]);

                var responseTask = client.DeleteAsync(endPoint);

                responseTask.Wait();

                var result = responseTask.Result;

                if (!result.IsSuccessStatusCode)
                    throw new Exception($"Failed to delete data to {endPoint}.");
            }
        }
    }
}