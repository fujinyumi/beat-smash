#!/usr/bin/python
import time
import sys
from collections import Counter

keysList = ['Space', 'J', 'F', 'K', 'D', 'J K', 'D F', 'F J', 'D K', 'D Space', 'F Space', 'J Space', 'K Space', 'D J', 'F K', 'D F J', 'F J K', 'D J K', 'D F K', 'D F Space', 'Space J K', 'D Space K', 'F Space J', 'D Space J', 'F Space K', 'D F J K', 'F Space J K', 'D F Space J', 'D Space J K', 'D F Space K', 'D F Space J K']
difficultyList = {"easy": 0, "medium": 3, "hard": 15, "impossible": 20}

def assignChords(beats,chords):
  beatChords = []
  chorditer = iter(chords)
  start, end, chord = next(chorditer)
  for beat in beats:
    while beat >= float(end):
      start, end, chord = next(chorditer)
    beatChords.append((beat,chord))
  return beatChords


#TODO: unhardcode difficulty
def assignKeys(beats, chords, difficulty):
  beatChords = assignChords(beats, chords)
  chordFreq = Counter([chord for sec, chord in beatChords]).most_common()
  chordFreq = {chord: i for i, (chord, n) in enumerate(chordFreq)}
  beatKeys = []
  for b, c in beatChords:
    c = keysList[(chordFreq[c] + difficultyList[difficulty])%31]
    beatKeys.append((b,c))
  return beatKeys


def fancyPrint(beatKeys, msi, fileLoc):
  f = open(fileLoc, "w+")
  print >> f, msi
  for sec,keys in beatKeys:
    for key in keys.split():
      print >> f, "{},{},0".format(int(sec*1000), key)
  f.close();