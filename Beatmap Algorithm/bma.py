#!/usr/bin/python

#Author: Ivy Wang
#Input: music file, output destination, difficulty level
#Output: .btmp file of music file
#Usage: python bma.py [input music] [output] [easy/medium/hard/impossible]

import time
import sys
import bmaFunctions
import numpy
from madmom.features.chords import DeepChromaChordRecognitionProcessor
from madmom.audio.chroma import DeepChromaProcessor
from madmom.features.beats import DBNBeatTrackingProcessor
from madmom.features.beats import RNNBeatProcessor


#Setting up Deep Chroma Chord Recognition Processor
dcp = DeepChromaProcessor()
decode = DeepChromaChordRecognitionProcessor()
chroma = dcp(sys.argv[1])
chords = decode(chroma)


#Setting up Dynamic Baysian Network Tracking Processor
proc = DBNBeatTrackingProcessor(fps=100)
act = RNNBeatProcessor()(sys.argv[1])
beats = proc(act)


#calculating msi
beatsArray = numpy.array(beats)
msi = numpy.mean(beatsArray[1:]-beatsArray[:-1])*1000

beatmap = bmaFunctions.assignKeys(beats, chords, sys.argv[3])
if msi < 360:
  del beatmap[1::2]

#generating and printing beatmap
bmaFunctions.fancyPrint(beatmap, msi, sys.argv[2])


#TODO: eliminate trailing Ns