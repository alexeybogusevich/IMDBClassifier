import pickle
from sklearn.feature_extraction.text import TfidfVectorizer
import pandas as pd


pickle_model_file = 'finalized_model.sav'
pickle_vectorizer = 'vectorizer.sav'
loaded_model = pickle.load(open(pickle_model_file, 'rb'))
loaded_vectorizer = pickle.load(open(pickle_vectorizer, 'rb'))

pred_file = r'D:\Programming\Python\imdbGenreClassification-master\data\pred.csv'
pred = pd.read_csv(pred_file)
vect = loaded_vectorizer.transform(pred['plot'])
res = loaded_model.predict(vect)
print(res[0])
