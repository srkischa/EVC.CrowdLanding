# Stage 1
FROM node:11 as react-build
WORKDIR /clientapp
COPY EVC.CrowdLanding.Client ./
RUN npm install
RUN npm run build

# Stage: 2 — the production environment 
FROM nginx:alpine 
COPY --from=react-build /clientapp/build /usr/share/nginx/html 
EXPOSE 80 
CMD ["nginx", "-g", "daemon off;"]