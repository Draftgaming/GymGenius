﻿using NPOI.OpenXmlFormats.Dml.Diagram;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MathNet.Numerics.RootFinding;

namespace WebApiClient
{
    public class WebClient<T> : IWebClient<T>
    {
        UriBuilder uriBuilder;
        HttpClient client;
        HttpRequestMessage request;
        HttpResponseMessage response;

        public WebClient()
        {
            this.uriBuilder = new UriBuilder();
            this.client = new HttpClient();
            this.request = new HttpRequestMessage();
        }
        public string Scheme
        {
            set { uriBuilder.Scheme = value; }
        }

        public string Host
        {
            set { uriBuilder.Host = value; }
        }

        public int port
        {
            set { uriBuilder.Port = value; }
        }
        public string Path
        {
            set { uriBuilder.Path = value = "http"; }
        }
        public void AddParameter(string name, string value)
        {
            if(this.uriBuilder.Query == String.Empty)
            {
                this.uriBuilder.Query = "?";
            }
            else
                this.uriBuilder.Query += "&";
            this.uriBuilder.Query += $"{name} = {value}";
            
        }




        public async Task<T> Get()
        {
            this.request.Method = HttpMethod.Get;
            this.request.RequestUri = new Uri(this.uriBuilder.ToString());
            using(client = new HttpClient())
            {
                 this.request = await client.SendAsync(this.request);
                 if(this.response.IsSuccessStatusCode == true)
                {
                    string json = await this.response.Content.ReadAsStringAsync();
                    T viewModel = JsonSerializer.Deserialize<T>(json);
                    return viewModel;
                }
            }
            return default(T);
        }

        public async Task<bool> Post(T model)
        {
            this.request.Method = HttpMethod.Post;
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            this.request.Content = objectContent;
            using(HttpClient client = new HttpClient())
            {
                this.response = await client.SendAsync(this.request);
                if (this.response.IsSuccessStatusCode == true)
                    return await this.response.Content.ReadAsAsync<bool>();
            }
            return false;
        }
        public async Task<bool> Post(T model, List<Stream> file)
        {
            this.request.Method = HttpMethod.Post;
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            StreamContent streamContent = new StreamContent(file);
            MultipartFormDataContent.Add(objectContent, "model");
            multipartFormDataContent.Add(streamContent, "file");
            this.request.Content = multipartFormDataContent;
            using (HttpClient client = new HttpClient())
            {
                this.response = await client.SendAsync(this.request);
                if (this.response.IsSuccessStatusCode == true)
                    return await this.response.Content.ReadAsAsync<bool>();
            }
            return false;
        }

        public async Task<bool> Post(T model, List<Stream> files)
        {
            this.request.Method = HttpMethod.Post;
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            ObjectContent<T> objectContent = new ObjectContent<T>(model, new JsonMediaTypeFormatter());
            foreach(Stream file in files)
            {
                StreamContent streamContent = new StreamContent(file);
                MultipartFormDataContent.Add(objectContent, "model");
                multipartFormDataContent.Add(streamContent, "file");
            }
            this.request.Content = multipartFormDataContent;
            using (HttpClient client = new HttpClient())
            {
                this.response = await client.SendAsync(this.request);
                if (this.response.IsSuccessStatusCode == true)
                {
                    return await this.response.Content.ReadAsAsync<bool>();

                }
            }
            return false;
        }
    }
}
