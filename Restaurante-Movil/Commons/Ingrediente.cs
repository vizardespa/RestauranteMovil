using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

public partial class Ingrediente : Entidad
{
    #region Primitive Properties
    public virtual int Id
    {
        get;
        set;
    }
    public virtual short Tipo
    {
        get;
        set;
    }
    public virtual decimal Cantidad
    {
        get;
        set;
    }

    public enum TipoIngrediente
    {
        ALCOHOL = 1,
        AVE,
        CARNE,
        CONDIMENTO,
        ESPECIA,
        FRUTA,
        GASEOSA,
        GRANO,
        JUGO,
        LACTEO,
        MARISCO,
        TUBERCULO,
        VERDURA
    }
    public static int AmountTipos { get { return 13; } }

    public string StringTipoIngrediente { get; set; }

    #endregion

}