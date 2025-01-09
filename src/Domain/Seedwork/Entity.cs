using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Seedwork;

public abstract class Entity
{
	protected Entity()
	{
		Id = Guid.NewGuid();
		InsertDateTime = DateTime.Now;
	}

	[Key]
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public Guid Id { get; private set; }

	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset InsertDateTime { get; private set; }
}