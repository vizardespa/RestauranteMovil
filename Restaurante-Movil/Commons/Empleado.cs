
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

public class Empleado : Entidad
{
    #region Primitive Properties
    public int Id
    {
        get;
        set;
    }
    public string Apellido
    {
        get;
        set;
    }
    public short Puesto
    {
        get;
        set;
    }
    public decimal Sueldo
    {
        get;
        set;
    }
    public System.DateTime Contratacion
    {
        get;
        set;
    }
    public bool Activo
    {
        get;
        set;
    }

    public enum Tipo
    {
        ADMINISTRATIVO = 1,
        CAJERO,
        COCINERO,
        MESERO
    }
    public static int AmountTipos { get { return 4; } }

    public string StringTipo { get; set; }

    #endregion


}