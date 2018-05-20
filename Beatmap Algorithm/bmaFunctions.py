#!/usr/bin/python
import time
import sys
from collections import Counter

keysList = ['Space', 'J', 'F', 'K', 'D', 'J K', 'D F', 'F J', 'D K', 'D Space', 'F Space', 'J Space', 'K Space']

def assignChords(beats,chords):
  beatChords = []
  chorditer = iter(chords)
  start, end, chord = next(chorditer).split()
  for beat in beats:
    while beat >= float(end):
      start, end, chord = next(chorditer).split()
    beatChords.append((beat,chord))
  return beatChords


# TODO: always assign N to space
#Check if too many keys
def assignKeys(beats, chords):
  beatChords = assignChords(beats, chords)
  chordFreq = Counter([chord for sec, chord in beatChords]).most_common()
  chordFreq = {chord: i for i, (chord, n) in enumerate(chordFreq)}
  beatKeys = []
  for b, c in beatChords:
    c = keysList[chordFreq[c]]
    beatKeys.append((b,c))
  return beatKeys





def fancyPrint(beatKeys, msi):
  print msi
  for sec,keys in beatKeys:
    for key in keys.split():
      print "{},{},0".format(int(sec*1000), key)