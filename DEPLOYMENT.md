# Deployment

The deployment of this project is done in two parts. The first part deploys the frontend, the second part deploys the backend.

## Deploying the frontend

> Deployment of the frontend website is done automatically everytime master is updated. However, there's also the option to trigger the deployments manually.

### Manual Deployment

First, you need to install the Netlify CLI and then login to your Netlify account:

`npm install -g netlify-cli`
`netlify login`

Then, after you've made your desired changes to the project, you have to rebuild the site:

`npm run build`

**Staging**
To deploy the project from your local environment to a "preview" or development site, run:

`netlify deploy --dir=dist/`

**Production**
This will generate a "preview" site where you can see the new site, without changing the production site.

Before you deploy to production, you should always make sure your changes commited to `master`.

To deploy the project from your local environment to the production site, run:

`netlify deploy --dir=dist/ --prod`

This will deploy your local version to the production site directly.

## Deploying the backend

First, you need to install the [Heroku CLI](https://devcenter.heroku.com/articles/heroku-cli/) and then login to your Heroku account and the Heroku Container Registry:

`heroku login`
`heroku container:login`

Then, after you've made your desired changes to the project, you have to rebuild the Docker image and push it to the docker registry:

`heroku container:push web`

Finally, make a new release to deploy your app:

`heroku container:release web`

The project should now be running at https://bluepos-back.herokuapp.com/
