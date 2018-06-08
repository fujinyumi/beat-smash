#!/usr/bin/python
import time
import sys

#grabbing beat file
filename = sys.argv[1]

##for beat tracker
lines = [float(x) for x in open(filename).read().splitlines()]

start_time = time.time()
for x in lines:
  next_wake = start_time + x
  time.sleep(next_wake - time.time())
  print "Onset at {}".format(x)


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
