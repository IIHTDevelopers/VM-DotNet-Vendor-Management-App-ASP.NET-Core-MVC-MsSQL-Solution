using VendorManagementApp.DAL.Interface;
using VendorManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace VendorManagementApp.DAL.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private VendorDbContext _context;
        public VendorRepository(VendorDbContext Context)
        {
            this._context = Context;
        }
      
        public Vendor GetVendorById(int vendorId)
        {
            return _context.Vendors.Find(vendorId);
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return _context.Vendors.ToList();
        }

        public Vendor AddVendor(Vendor vendor)
        {
            if (vendor != null)
            {
                _context.Vendors.Add(vendor);
                _context.SaveChanges(); // Save changes to the database
                return vendor; // Return the added vendor with the updated Id
            }
            else
            {
                // Handle the case where the input vendor is null
                throw new ArgumentNullException(nameof(vendor), "Vendor object cannot be null");
            }
        }


        public Vendor UpdateVendor(Vendor updatedVendor)
        {
            if (updatedVendor != null)
            {
                var existingVendor = _context.Vendors.Find(updatedVendor.VendorId);

                if (existingVendor != null)
                {
                    // Update properties of the existing vendor with the new values
                    _context.Entry(existingVendor).CurrentValues.SetValues(updatedVendor);
                    _context.SaveChanges(); // Save changes to the database
                    return existingVendor;
                }
                else
                {
                    // Handle the case where the vendor with the given Id is not found
                    throw new ArgumentException($"Vendor with Id {updatedVendor.VendorId} not found", nameof(updatedVendor));
                }
            }
            else
            {
                // Handle the case where the input vendor is null
                throw new ArgumentNullException(nameof(updatedVendor), "Updated vendor object cannot be null");
            }
        }

        public Vendor DeleteVendor(int vendorId)
        {
            var vendorToDelete = _context.Vendors.Find(vendorId);

            if (vendorToDelete != null)
            {
                _context.Vendors.Remove(vendorToDelete);
                _context.SaveChanges(); // Save changes to the database
                return vendorToDelete;
            }
            else
            {
                // Handle the case where the vendor with the given Id is not found
                throw new ArgumentException($"Vendor with Id {vendorId} not found", nameof(vendorId));
            }
        }
    }
}
