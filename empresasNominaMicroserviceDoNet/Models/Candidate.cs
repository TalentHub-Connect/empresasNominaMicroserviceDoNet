﻿using System;
using System.Collections.Generic;

namespace empresasNominaMicroserviceDoNet.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string EmploymentExchange { get; set; } = null!;

    public bool Status { get; set; }

    public int Curriculum_id { get; set; }

    public int TalentSoftUser_id { get; set; }

}
