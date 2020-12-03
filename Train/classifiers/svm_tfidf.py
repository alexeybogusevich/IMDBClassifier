from sklearn import svm
from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from utils import predict
from preprocess import preprocess
import pandas as pd
import pickle

pickle_model_file = 'finalized_model.sav'
pickle_vectorizer_file = 'vectorizer.sav'
pred_file = r'D:\Programming\Python\imdbGenreClassification-master\data\pred.csv'

data_features = preprocess(r'D:\Programming\Python\imdbGenreClassification-master\data\trainingSet.csv')
train_data, test_data = train_test_split(data_features, test_size=0.1, random_state=42)

vectorizer = TfidfVectorizer(min_df=2, tokenizer=None, preprocessor=None, stop_words=None)

train_data_features = vectorizer.fit_transform(train_data['plot'])
train_data_features = train_data_features.toarray()

pickle.dump(vectorizer, open(pickle_vectorizer_file, 'wb'))

lin_clf = svm.LinearSVC()
lin_clf.fit(train_data_features, train_data['tags'])

predict(vectorizer, lin_clf, test_data)

pickle.dump(lin_clf, open(pickle_model_file, 'wb'))

pred = pd.read_csv(pred_file)
vect = vectorizer.transform(pred['plot'])
res = lin_clf.predict(vect)
print(res[0])
