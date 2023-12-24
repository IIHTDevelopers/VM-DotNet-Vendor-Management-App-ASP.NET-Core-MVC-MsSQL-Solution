
using VendorManagementApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorManagementApp.DAL.Interface
{
    public interface IVendorRepository
    {
        Vendor GetVendorById(int vendorId);
        IEnumerable<Vendor> GetAllVendors();
        Vendor AddVendor(Vendor vendor);
        Vendor UpdateVendor(Vendor vendor);
        Vendor DeleteVendor(int vendorId);
    }
}