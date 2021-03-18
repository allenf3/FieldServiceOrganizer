using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Shared
{
    public class MelissaAddress
    {
        public int Id { get; set; }
        public string FormattedAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public string SubPremises { get; set; }
        public string DoubleDependentLocality { get; set; }
        public string DependentLocality { get; set; }
        public string Locality { get; set; }
        public string SubAdministrativeArea { get; set; }
        public string AdministrativeArea { get; set; }
        public string PostalCode { get; set; }
        public string PostalCodeType { get; set; } // P = PO Box, U = Unique (large org or govt. institution), M = Millitary, [Empty] = Regular
        public string AddressType { get; set; }
        public string AddressKey { get; set; }
        public string SubNationalArea { get; set; }
        public string CountryName { get; set; }
        public string CountryISO3166_1_Alpha2 { get; set; }
        public string CountryISO3166_1_Alpha3 { get; set; }
        public string CountryISO3166_1_Numeric { get; set; }
        public string CountrySubdivisionCode { get; set; }
        public string Thoroughfare { get; set; }
        public string ThoroughfarePreDirection { get; set; }
        public string ThoroughfareLeadingType { get; set; }
        public string ThoroughfareName { get; set; }
        public string ThoroughfareTrailingType { get; set; }
        public string ThoroughfarePostDirection { get; set; }
        public string DependentThoroughfare { get; set; }
        public string DependentThoroughfarePreDirection { get; set; }
        public string DependentThoroughfareLeadingType { get; set; }
        public string DependentThoroughfareName { get; set; }
        public string DependentThoroughfareTrailingType { get; set; }
        public string DependentThoroughfarePostDirection { get; set; }
        public string Building { get; set; }
        public string PremisesType { get; set; }
        public string PremisesNumber { get; set; }
        public string SubPremisesType { get; set; }
        public string SubPremisesNumber { get; set; }
        public string PostBox { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MelissaAddressKey { get; set; }
        public string MelissaAddressKeyBase { get; set; }
        public string UTC { get; set; }
        public string DeliveryIndicator { get; set; } // R = residence, B = business, U = unknown
        public string DST { get; set; } // Y or N (observes Daylight Savings Time)
        public string CensusKey { get; set; }
    }
}
