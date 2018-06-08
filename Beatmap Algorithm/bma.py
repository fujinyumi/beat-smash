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
from madmom.features.onsets import OnsetPeakPickingProcessor
from madmom.features.onsets import RNNOnsetProcessor


#Setting up Deep Chroma Chord Recognition Processor
dcp = DeepChromaProcessor()
decode = DeepChromaChordRecognitionProcessor()
chroma = dcp(sys.argv[1])
chords = decode(chroma)


#Setting up Onset Peak Picking Processor
proc = OnsetPeakPickingProcessor(fps=100, threshold=0.7, pre_avg = 0.25, post_avg = 0.25, smooth = 0.1)
act = RNNOnsetProcessor()(sys.argv[1])
beats = proc(act)


#calculating msi
beatsArray = numpy.array(beats)
msi = numpy.mean(beatsArray[1:]-beatsArray[:-1])*1000

#generating and printing beatmap
bmaFunctions.fancyPrint(bmaFunctions.assignKeys(beats, chords, sys.argv[3]), msi, sys.argv[2])


