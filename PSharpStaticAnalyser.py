#!/usr/bin/env python

import argparse
import os
import subprocess
import sys

class Options:
    ToolPath = ""
    Solution = ""

class Benchmarks(object):
    default = ['BoundedAsync', 'German', 'BasicPaxos', 'TwoPhaseCommit', 'Chord', 'MultiPaxos',
               'Raft', 'ChainReplication']

    racy = ['BoundedAsyncRacey', 'GermanRacey', 'BasicPaxosRacey', 'TwoPhaseCommitRacey',
             'ChordRacey', 'MultiPaxosRacey', 'RaftRacey', 'ChainReplicationRacey']

    soter = ['Leader', 'Pi', 'Chameneos', 'Swordfish']

def crunchBenchmarks(args):
    Options.ToolPath = os.path.join('Include', 'PSharpStaticAnalyser.exe')
    Options.Solution = os.path.join('StaticAnalysisBenchmarks.sln')
    print(Options.Solution)
    print("Running test 1 (out of 5) - Analysing PSharpBench-default without xSA ...\n")
    for benchmark in Benchmarks.default:
        print("  Analysing (without xSA): " + benchmark + "\n")
        tool = subprocess.Popen([Options.ToolPath, "/s:" + Options.Solution, "/p:" + benchmark, "/skipwarnings", '/nostatetransitionanalysis', '/time'],
            stdout=subprocess.PIPE, shell=True)
        out, err = tool.communicate()
        tool.kill()
        print(out)

    print("Running test 2 (out of 5) - Analysing PSharpBench-default with xSA ...\n")
    for benchmark in Benchmarks.default:
        print("  Analysing (with xSA): " + benchmark + "\n")
        tool = subprocess.Popen([Options.ToolPath, "/s:" + Options.Solution, "/p:" + benchmark, "/skipwarnings", '/time'],
            stdout=subprocess.PIPE, shell=True)
        out, err = tool.communicate()
        tool.kill()
        print(out)

    print("Running test 3 (out of 5) - Analysing PSharpBench-racy ...\n")
    for benchmark in Benchmarks.racy:
        print("  Analysing: " + benchmark + "\n")
        tool = subprocess.Popen([Options.ToolPath, "/s:" + Options.Solution, "/p:" + benchmark, "/skipwarnings", '/time'],
            stdout=subprocess.PIPE, shell=True)
        out, err = tool.communicate()
        tool.kill()
        print(out)

    print("Running test 4 (out of 5) - Analysing SOTER benchmarks without xSA ...\n")
    for benchmark in Benchmarks.soter:
        print("  Analysing (without xSA): " + benchmark + "\n")
        tool = subprocess.Popen([Options.ToolPath, "/s:" + Options.Solution, "/p:" + benchmark, "/skipwarnings", '/nostatetransitionanalysis', '/time'],
            stdout=subprocess.PIPE, shell=True)
        out, err = tool.communicate()
        tool.kill()
        print(out)

    print("Running test 5 (out of 5) - Analysing SOTER benchmarks with xSA ...\n")
    for benchmark in Benchmarks.soter:
        print("  Analysing (with xSA): " + benchmark + "\n")
        tool = subprocess.Popen([Options.ToolPath, "/s:" + Options.Solution, "/p:" + benchmark, "/skipwarnings", '/time'],
            stdout=subprocess.PIPE, shell=True)
        out, err = tool.communicate()
        tool.kill()
        print(out)

    return 0

if __name__ == '__main__':
    parser = argparse.ArgumentParser(description='Script for running the benchmarks using the P# static analyser.')
    args = vars(parser.parse_args())

    rc = crunchBenchmarks(args)

    sys.exit(rc)
