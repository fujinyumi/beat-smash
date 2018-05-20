#!/usr/bin/python
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


#grabbing beat file
#beatFile = sys.argv[1]
#
##grabbing chord file
#chordFile = sys.argv[2]


#extracting beats
#beats =[float(x) for x in open(beatFile).read().splitlines()]

##extracting chords
#chords = open(chordFile).read().splitlines();

#calculating msi
beatsArray = numpy.array(beats)
msi = numpy.mean(beatsArray[1:]-beatsArray[:-1])*1000

#generating and printing beatmap
bmaFunctions.fancyPrint(bmaFunctions.assignKeys(beats, chords), msi, sys.argv[2])


