/**
 * Autogenerated by Thrift Compiler (@PACKAGE_VERSION@)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Protol
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Position : TBase
  {
    private double _x;
    private double _y;
    private double _z;

    public double X
    {
      get
      {
        return _x;
      }
      set
      {
        __isset.x = true;
        this._x = value;
      }
    }

    public double Y
    {
      get
      {
        return _y;
      }
      set
      {
        __isset.y = true;
        this._y = value;
      }
    }

    public double Z
    {
      get
      {
        return _z;
      }
      set
      {
        __isset.z = true;
        this._z = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool x;
      public bool y;
      public bool z;
    }

    public Position() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 10:
              if (field.Type == TType.Double) {
                X = iprot.ReadDouble();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.Double) {
                Y = iprot.ReadDouble();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 30:
              if (field.Type == TType.Double) {
                Z = iprot.ReadDouble();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Position");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.x) {
          field.Name = "x";
          field.Type = TType.Double;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteDouble(X);
          oprot.WriteFieldEnd();
        }
        if (__isset.y) {
          field.Name = "y";
          field.Type = TType.Double;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteDouble(Y);
          oprot.WriteFieldEnd();
        }
        if (__isset.z) {
          field.Name = "z";
          field.Type = TType.Double;
          field.ID = 30;
          oprot.WriteFieldBegin(field);
          oprot.WriteDouble(Z);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Position(");
      bool __first = true;
      if (__isset.x) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("X: ");
        __sb.Append(X);
      }
      if (__isset.y) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Y: ");
        __sb.Append(Y);
      }
      if (__isset.z) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Z: ");
        __sb.Append(Z);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
