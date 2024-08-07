﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class MstProfile
{
    public Guid Id { get; set; }

    public int UserId { get; set; }

    public string? NamaLengkap { get; set; }

    public string? Alamat { get; set; }

    public virtual MstUser User { get; set; } = null!;
}
