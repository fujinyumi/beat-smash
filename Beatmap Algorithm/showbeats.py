#!/usr/bin/python
import time
import sys

#grabbing beat file
filename = sys.argv[1]


lines = [float(x) for x in open(filename).read().splitlines()]
#lines.insert(0,0)

start_time = time.time()
for x in lines:
  next_wake = start_time + x
  time.sleep(next_wake - time.time())
  print "Beat at {}".format(x)
