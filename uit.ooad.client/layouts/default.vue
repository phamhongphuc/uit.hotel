<template>
    <div id="layout">
        <navbar- />
        <main>
            <sidebar- />
            <div class="content">
                <div class="container-staff"><nuxt /></div>
            </div>
        </main>
        <no-ssr>
            <notifications
                animation-type="velocity"
                position="left bottom"
                :duration="1500"
            />
        </no-ssr>
    </div>
</template>
<style lang="scss">
#layout {
    position: fixed;
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    > main {
        display: flex;
        flex: 1;
        max-height: calc(100% - 3.5rem);
        .content {
            flex: 1;
            padding: 0.75rem 0;
            overflow-y: scroll;
        }
    }
}

.container-staff {
    @include make-container();
    @include make-container-max-widths(
        (
            md: 720px - 100px,
            lg: 960px - 200px,
            xl: 1140px - 200px,
        )
    );
}
</style>
