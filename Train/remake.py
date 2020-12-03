import pandas as pd

f = pd.read_csv('data/trainingSet.csv')
f = f.iloc[:, :-2]

print(pd.unique(f['Genre1']))
