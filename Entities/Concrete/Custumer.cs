using System;
using Entities.Abstract;

namespace Entities.Concrete;

	public class Custumer:IEntity
	{
    public int CustumerId { get; set; }
    public string? ContactName { get; set; }
    public string? CompanyName { get; set; }
    public string? City { get; set; }
}

