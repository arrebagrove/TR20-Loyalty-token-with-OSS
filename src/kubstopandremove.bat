kubectl delete rc -l run=ready20
kubectl delete svc -l run=ready20

kubectl create -f kubdeploy.yaml