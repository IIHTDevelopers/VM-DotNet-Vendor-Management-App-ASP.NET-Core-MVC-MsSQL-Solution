using VendorManagementApp.DAL.Interface;
using VendorManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VendorManagementApp.DAL.Repository
{
    public class VendorManagementService : IVendorInterface
    {
        private IVendorRepository _repo;
        public VendorManagementService(IVendorRepository repo)
        {
            this._repo = repo;
        }

        public Vendor AddVendor(Vendor vendor)
        {
            return _repo.AddVendor(vendor);
        }

        public Vendor DeleteVendor(int vendorId)
        {
            return _repo.DeleteVendor(vendorId);
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return _repo.GetAllVendors();
        }

        public Vendor GetVendorById(int vendorId)
        {
            return _repo.GetVendorById(vendorId);
        }

        public Vendor UpdateVendor(Vendor vendor)
        {
            return _repo.UpdateVendor(vendor);
        }
    }
}