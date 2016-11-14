using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UPnP;

namespace RadioThermostat.Api
{
    public class Discovery //: IDisposable
    {
        const string WM_DISCOVERMessage = "TYPE: WM-DISCOVER\r\nVERSION: 1.0\r\n\r\nservices: com.marvell.wm.system*\r\n\r\n";
        
        public Discovery()
        {
        }

        public async Task SearchAsync()
        {
            var devices = await new Ssdp().SearchDevices("");

            foreach (var device in devices)
            {
            }
        }

        //void Disco_DeviceFound(object sender, DeviceFoundEventArgs e)
        //{
        //    string location = string.Empty;
        //    string service = string.Empty;

        //    if (!e.Results.TryGetValue("SERVICE", out service))
        //        return;
        //    if (service.StartsWith("com.marvell.wm") && e.Results.TryGetValue("LOCATION", out location))
        //    {
        //        var newTstat = new ThermostatBase(location);
        //        var existingTstat = Results.Where(t => t.Equals(newTstat)).SingleOrDefault();
        //        if (existingTstat == null)
        //            Results.Add(newTstat);
        //    }
        //}

        //public void Dispose()
        //{
        //    this.Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_Ssdp != null)
        //        {
        //            _Ssdp.Dispose();
        //            _Ssdp = null;
        //        }
        //    }
        //}
    }
}
