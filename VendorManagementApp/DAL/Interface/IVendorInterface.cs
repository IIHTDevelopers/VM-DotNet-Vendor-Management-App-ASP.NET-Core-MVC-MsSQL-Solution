using VendorManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorManagementApp.DAL.Interface
{
    public interface IVendorInterface 
    {
        Vendor GetVendorById(int vendorId);
        IEnumerable<Vendor> GetAllVendors();
        Vendor AddVendor(Vendor vendor);
        Vendor UpdateVendor(Vendor vendor);
        Vendor DeleteVendor(int vendorId);
    }
}