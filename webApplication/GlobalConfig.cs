using System.Diagnostics;

namespace webApplication
{
    //klasa singleton, publiczna, widziana w całym programie, BaseAddress musi być zmieniony na nasz adres Azure
    //przykladowe uzycie w metodzie GetAllUsers
    //do elementow z klasy odnosimy sie w taki sposob: GlobalConfig.Instance.HttpClientInstance
    //i takie HttpClientInstance bedzie widoczne w kazdej klasie w kodzie webApplication

    public sealed class GlobalConfig
    {
        private static GlobalConfig instance;

        private static readonly object padlock = new object();

        public HttpClient HttpClientInstance { get; set; }

        private GlobalConfig()
        {

        }

        public static GlobalConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new GlobalConfig();

                            instance.HttpClientInstance = new HttpClient();

                            instance.HttpClientInstance.BaseAddress = new Uri("https://azure.net/");
                            instance.HttpClientInstance.DefaultRequestHeaders.Accept.Clear();
                            instance.HttpClientInstance.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        }
                    }
                }
                return instance;
            }
        }

        public async Task GetAllUsers()
        {
            try
            {
                HttpResponseMessage getAllUsersResponse = await GlobalConfig.Instance.HttpClientInstance.GetAsync("api/users/all");

                if (getAllUsersResponse.IsSuccessStatusCode)
                {
                    string jsonAllUsersList = await getAllUsersResponse.Content.ReadAsStringAsync();
                    //Instance.UserList = JsonConvert.DeserializeObject<List<User>>(jsonAllUsersList);                  
                }
                else
                {
                    Debug.Write("Request not successful");
                }
            }
            catch
            {
                Debug.Write("Unable to connect to server");
            }
        }
    }
}
