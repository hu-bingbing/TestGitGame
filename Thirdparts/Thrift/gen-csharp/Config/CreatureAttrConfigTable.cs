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
  public partial class CreatureAttrConfigTable : TBase
  {
    private Dictionary<int, CreatureAttrConfig> _creatureConfigMap;

    public Dictionary<int, CreatureAttrConfig> CreatureConfigMap
    {
      get
      {
        return _creatureConfigMap;
      }
      set
      {
        __isset.creatureConfigMap = true;
        this._creatureConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool creatureConfigMap;
    }

    public CreatureAttrConfigTable() {
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
                  CreatureConfigMap = new Dictionary<int, CreatureAttrConfig>();
                  TMap _map0 = iprot.ReadMapBegin();
                  for( int _i1 = 0; _i1 < _map0.Count; ++_i1)
                  {
                    int _key2;
                    CreatureAttrConfig _val3;
                    _key2 = iprot.ReadI32();
                    _val3 = new CreatureAttrConfig();
                    _val3.Read(iprot);
                    CreatureConfigMap[_key2] = _val3;
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
        TStruct struc = new TStruct("CreatureAttrConfigTable");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (CreatureConfigMap != null && __isset.creatureConfigMap) {
          field.Name = "creatureConfigMap";
          field.Type = TType.Map;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, CreatureConfigMap.Count));
            foreach (int _iter4 in CreatureConfigMap.Keys)
            {
              oprot.WriteI32(_iter4);
              CreatureConfigMap[_iter4].Write(oprot);
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
      StringBuilder __sb = new StringBuilder("CreatureAttrConfigTable(");
      bool __first = true;
      if (CreatureConfigMap != null && __isset.creatureConfigMap) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CreatureConfigMap: ");
        __sb.Append(CreatureConfigMap);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}