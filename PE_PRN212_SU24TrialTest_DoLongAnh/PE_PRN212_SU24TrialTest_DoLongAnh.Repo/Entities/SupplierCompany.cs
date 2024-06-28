﻿using System;
using System.Collections.Generic;

namespace PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;

public partial class SupplierCompany
{
    public string SupplierId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string? SupplierDescription { get; set; }

    public string? PlaceOfOrigin { get; set; }

    public virtual ICollection<AirConditioner> AirConditioners { get; set; } = new List<AirConditioner>();
}
