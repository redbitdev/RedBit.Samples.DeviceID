using System;
using System.Collections.Generic;
using System.Text;

namespace RedBit.Mobile
{
    public class Hardware
    {
        private static Hardware _Default;
        public static Hardware Default
        {
            get
            {
                return _Default ?? (_Default = new Hardware());
            }
        }

        /// <summary>
        /// Gets a device unique identifier
        /// </summary>
        public string DeviceId
        {
            get
            {
                return GetDeviceIdInternal();
            }
        }

        /// <summary>
        /// Gets a device unique identifier depending on the platform
        /// </summary>
        /// <returns>string representing the unique id</returns>
        private string GetDeviceIdInternal()
        {
            var id = default(string);
#if __IOS__
            id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
#elif WINDOWS_PHONE
            id = Windows.Phone.System.Analytics.HostInformation.PublisherHostId;
#else
            id = Android.OS.Build.Serial;
#endif
            return id;
        }
    }
}
