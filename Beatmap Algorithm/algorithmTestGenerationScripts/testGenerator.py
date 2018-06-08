#!/usr/bin/python

## Author: Ivy Wang
#Python sript takes in a .btmp file and outputs test file (equivalent to TestA.cs)
#Example: python testGenerator.py ../beatmap.btmp > TestA.cs
#I wrote this at 4AM in the morning, so use at your own risk.

import time
import sys
from collections import Counter

print "using System.Collections;"
print "using System.Collections.Generic;"
print "using UnityEngine;"

print "public class TestA {"
print "  public void LoadUpcomingBeats(SortedDictionary<int, List<BeatInfo>> upcomingBeats){"

beatmap = open(sys.argv[1]).read().splitlines()
listno = 0
line = beatmap[1]
line = line.split(',')
prevline = 'N'
msec = float(line[0])
for i in range(1,len(beatmap)):
  line = beatmap[i]
  line = line.split(',')
  if (i == len(beatmap) or line[0] <> prevline):
    print "List<BeatInfo> listToInsert{} = new List<BeatInfo>();".format(listno)
    if(listno<>0):
      print "upcomingBeats.Add({}, listToInsert{});".format(int(msec), listno-1)
    prevline = line[0]
    listno+=1
  msec = float(line[0])
  print "listToInsert{}.Add(new BeatInfo(Lane.{}, BeatType.Hit, {}));".format(listno-1,line[1], int(msec))

print "upcomingBeats.Add({}, listToInsert{});".format(int(msec), listno-1)

print "}}"