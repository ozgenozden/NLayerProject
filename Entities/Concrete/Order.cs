using System;
using Entities.Abstract;

namespace Entities.Concrete;
  public class Order:IEntity
{
	public int OrderId { get; set; }
	public int CustumerId { get; set; }
	public int EmployeeId { get; set; }
	public DateTime OrderDate { get; set; }
	public string ShipCity { get; set; }
	 

}

