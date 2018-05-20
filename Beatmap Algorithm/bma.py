#!/usr/bin/python

#%matplotlib inline

import numpy as np
import matplotlib.pyplot as plt

import madmom



signal,sample_rate = madmom.audio.signal.load_wave_file('music/teen.wav')