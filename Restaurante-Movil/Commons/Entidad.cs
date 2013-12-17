using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


public class Entidad
{
    #region Primitive Properties
    /*public long Id
    {
        get;
        set;
    }*/
    public string Nombre { get; set; }
    public short Tipo
    {
        get;
        set;
    }


    #endregion


}