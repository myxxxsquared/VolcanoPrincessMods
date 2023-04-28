
#if false

using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace VolcanoPrincessMods
{
    [HarmonyPatch(typeof(NpcSys), "Load")]
    public class DumpNpcInfo
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonDataAll));
            foreach (Person person in NpcSys.AllPerson("", -1))
            {
                PersonDataAll personData = new PersonDataAll();
                personData.enName = person.enName;
                personData.chName = person.chName;
                personData.fame = person.fame;
                personData.lover = person.lover;
                personData.favor = person.favor;
                personData.natures = person.natures;
                personData.inAttri = person.inAttri;
                personData.addInAttri = person.addInAttri;
                personData.eloquence = person.eloquence;
                personData.relationLevel = person.relationLevel;
                personData.relationBools = person.relationBools;
                personData.sendGiftBools = person.sendGiftBools;
                personData.items = person.items;
                personData.eveStage = person.eveStage;
                personData.eqips = person.equips;
                personData.addFightAttri = person.addFightAttri;
                personData.majorScore = person.majorScore;
                personData.refuseInvitation = person.refuseInvitation;
                personData.haveSentFavItem = person.haveSentFavItems;
                StringWriter writer = new StringWriter();
                serializer.Serialize(writer, personData);
                VolcanoPrincessMods.ModLogger.LogInfo(writer.ToString());
            }
        }
    }

    public class PersonDataAll
    {
        public string enName;
        public string chName;
        public int fame;
        public int lover;
        public int favor;
        public int[] natures;
        public int[] inAttri;
        public int[] addInAttri;
        public int eloquence;
        public int relationLevel;
        public bool[] relationBools;
        public bool[] sendGiftBools;
        public List<int> items;
        public int eveStage;
        public int[] eqips;
        public int[] addFightAttri;
        public int[] majorScore;
        public bool refuseInvitation;
        public bool[] haveSentFavItem;
    }
}

#endif