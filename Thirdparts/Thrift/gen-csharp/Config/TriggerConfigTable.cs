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

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class TriggerConfigTable : TBase
  {
    private Dictionary<int, TriggerConfig> _triggerConfigMap;

    public Dictionary<int, TriggerConfig> TriggerConfigMap
    {
      get
      {
        return _triggerConfigMap;
      }
      set
      {
        __isset.triggerConfigMap = true;
        this._triggerConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool triggerConfigMap;
    }

    public TriggerConfigTable() {
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
              if (field.Type == TType.Map) {
                {
                  TriggerConfigMap = new Dictionary<int, TriggerConfig>();
                  TMap _map19 = iprot.ReadMapBegin();
                  for( int _i20 = 0; _i20 < _map19.Count; ++_i20)
                  {
                    int _key21;
                    TriggerConfig _val22;
                    _key21 = iprot.ReadI32();
                    _val22 = new TriggerConfig();
                    _val22.Read(iprot);
                    TriggerConfigMap[_key21] = _val22;
                  }
                  iprot.ReadMapEnd();
                }
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
        TStruct struc = new TStruct("TriggerConfigTable");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (TriggerConfigMap != null && __isset.triggerConfigMap) {
          field.Name = "triggerConfigMap";
          field.Type = TType.Map;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, TriggerConfigMap.Count));
            foreach (int _iter23 in TriggerConfigMap.Keys)
            {
              oprot.WriteI32(_iter23);
              TriggerConfigMap[_iter23].Write(oprot);
            }
            oprot.WriteMapEnd();
          }
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
      StringBuilder __sb = new StringBuilder("TriggerConfigTable(");
      bool __first = true;
      if (TriggerConfigMap != null && __isset.triggerConfigMap) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TriggerConfigMap: ");
        __sb.Append(TriggerConfigMap);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
