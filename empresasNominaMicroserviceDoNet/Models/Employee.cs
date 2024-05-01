using System;
using System.Collections.Generic;

namespace empresasNominaMicroserviceDoNet.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int Curriculum_id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string NameEmergencyContact { get; set; } = null!;

    public int EmergencyContact { get; set; }

    public int TalentSoftUser_id { get; set; }

}
