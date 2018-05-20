#!/usr/bin/python
import time
import sys

#grabbing beat file
filename = sys.argv[1]

#for chord tracker
lines = open(filename).read().splitlines();


sec, end, chord = lines[0].split()
print "Chord at {}, Count: {}".format(sec, chord)

start_time = time.time()
for line in lines[1:]:
  sec, end, chord = line.split()
  sec = float(sec)
  next_wake = start_time + sec
  time.sleep(next_wake - time.time())
  print "Chord at {}, Count: {}".format(sec, chord)