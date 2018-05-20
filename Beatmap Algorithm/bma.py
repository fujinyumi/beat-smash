#!/usr/bin/python
import time
import sys
import bmaFunctions


#TODO AUTOMATE CALLING MADMOM


#grabbing beat file
beatFile = sys.argv[1]

#grabbing chord file
chordFile = sys.argv[2]


#extracting beats
beats =[float(x) for x in open(beatFile).read().splitlines()]

#extracting chords
chords = open(chordFile).read().splitlines();

bmaFunctions.fancyPrint(bmaFunctions.assignKeys(beats, chords))




#start_time = time.time()
#for x in lines:
#  next_wake = start_time + x
#  time.sleep(next_wake - time.time())
#  print "Beat at {}".format(x)


#for downbeat tracker
#lines = open(filename).read().splitlines();
#
#start_time = time.time()
#for line in lines:
#  sec, count = line.split()
#  sec = float(sec)
#  next_wake = start_time + sec
#  if next_wake - time.time() > 0:
#    time.sleep(next_wake - time.time())
#    print "Beat at {}, Count: {}".format(sec, count)

