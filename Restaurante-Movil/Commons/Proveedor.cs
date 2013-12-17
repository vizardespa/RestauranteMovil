using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

public partial class Proveedor : Entidad
{
    #region Primitive Properties
    public virtual int Id
    {
        get;
        set;
    }
    public virtual long Telefono
    {
        get;
        set;
    }
    public virtual decimal Deuda
    {
        get;
        set;
    }

    #endregion

}