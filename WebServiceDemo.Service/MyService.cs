using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebServiceDemo.Service.ServiceReference1;

namespace WebServiceDemo.Service
{
    public class MyService
    {
        public Task<string> GetData(int value)
        {
            var binding=new BasicHttpBinding( BasicHttpSecurityMode.None);
            var address=new EndpointAddress("http://testmyws.azurewebsites.net/Service1.svc");
            Service1Client service = new Service1Client(binding, address);

            var task = new TaskCompletionSource<string>();
            service.GetDataCompleted += (sender, e) =>
            {
                if (e.Cancelled)
                    task.TrySetCanceled();
                else if (e.Error != null)
                    task.TrySetException(e.Error);
                else
                    task.TrySetResult(e.Result);
            };
            service.GetDataAsync(value);
            return task.Task;

        }
    }
}
